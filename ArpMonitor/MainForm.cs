using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace ArpMonitor
{



    public partial class MainForm : Form
    {
           public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Загружаем список вендоров
            if (!isOUILoaded)
            {
                LoadOUIList();
            }


        }


        /// <summary>
        /// Класс, в котором хранятся MAC и IP-адрес интерфейса
        /// </summary>
        public class IpMacInfo
        {
            public string ipAddr;
            public string macAddr;
            public string typeOfMac;

            public IpMacInfo(string ipAddr, string macAddr)
            {
                this.ipAddr = ipAddr;
                this.macAddr = macAddr;
            }
            
            public void setTypeOfMac (string type)
            {
                this.typeOfMac = type;
            }

        }
        /// <summary>
        /// Описывает струкутуру OUI
        /// </summary>
        public class OUIInfo
        {
            public string Mac;
            public string Vendor;

            public OUIInfo (string Mac, string Vendor)
            {
                this.Mac = Mac;
                this.Vendor = Vendor;             
            }
        }

        /// <summary>
        /// Флаг загрузки OUI-списка
        /// </summary>
   
        public bool isOUILoaded = false;
        public List<OUIInfo> OUIList = new List<OUIInfo>();

        private void buttonSendArp_Click(object sender, EventArgs e)
        {
            //Получим результат ARP-запроса
            string arpResult = GetArpResult();
            
            //Получим список MAC-адресов и IP - адресов
            if (arpResult == null)
            {
                MessageBox.Show("Не удалось получить список MAC-адресов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var arpList = GetMacTable(arpResult);

            //Классифицируем
            SetMacClassification(arpList);

            //Добавим их в список, а также создадим список индивидуальных адресов
            dataGridAddresses.Rows.Clear();

            var arpListDevices = new List<IpMacInfo>();
            //Удаляем дубликаты
            arpList = arpList.Distinct().ToList();

            //Добавим общий список адресов
            foreach (var dev in arpList)
            {
                dataGridAddresses.Rows.Add(GetImageTypeForMacClass(dev.typeOfMac), dev.ipAddr, dev.macAddr, dev.typeOfMac);
                if (dev.typeOfMac == "Индивидуальный")
                {
                    arpListDevices.Add(dev);
                }
            }
            

            //И список индивидуальных адресов :3
            dataGridDevices.Rows.Clear();

            foreach (var dev in arpListDevices)
            {
                dataGridDevices.Rows.Add(dev.ipAddr, dev.macAddr, GetVendor(dev.macAddr));
            }

        }

        /// <summary>
        /// Функция выполняет ARP-запрос
        /// </summary>
        /// <returns>
        /// string - в случае, если ARP-запрос выполнен успешно
        /// null - в случае неудачи
        /// </returns>
        private static string GetArpResult()
        {
            Process p = null;
            String output = string.Empty;
            try
            {
                //Попробуем запустить процесс с командой arp-a
                p = Process.Start(new ProcessStartInfo("arp", "-a")
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    StandardOutputEncoding = Encoding.GetEncoding(866)
                });

                output = p.StandardOutput.ReadToEnd();

                p.Close();

                return output;
            }

            catch
            {
                MessageBox.Show("Не удалось послать ARP-запрос", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        /// <summary>
        /// Функция преобразует вывод команды ARP-а в список IpMacInfo
        /// </summary>
        /// <param name="ArpResult"></param>
        /// <returns>
        /// </returns>
        private static List<IpMacInfo> GetMacTable(string ArpResult)
        {
            var IpMacList = new List<IpMacInfo>();
            //Парсим результат ARP-запроса
            foreach (var arp in ArpResult.Split(new char[] {'\n', '\r' }))
            {
                if (!string.IsNullOrEmpty(arp))
                {
                    var pieces = (from piece in arp.Split(new char[] { ' ', '\t' })
                                  where !string.IsNullOrEmpty(piece)
                                  select piece).ToArray();
                    if (pieces.Length == 3)
                    {
                        IpMacList.Add(new IpMacInfo(pieces[0], pieces[1]));
                    }
                        
                }
            }
            return IpMacList;
        }

        /// <summary>
        /// Метод классифицирует MAC-адреса
        /// </summary>
        /// <param name="IpMacList">Список адресов для классификации</param>
        private void SetMacClassification(List <IpMacInfo> IpMacList)
        {
            foreach (var IpMac in IpMacList)
            {
                if (IpMac.macAddr == "ff-ff-ff-ff-ff-ff")
                {
                    IpMac.setTypeOfMac("Широковещательный");
                }

                else if (IpMac.macAddr.Substring(0,2) == "01")
                {
                    IpMac.setTypeOfMac("Групповой");
                }

                else
                {
                    IpMac.setTypeOfMac("Индивидуальный");
                }
            }
        }

        /// <summary>
        /// Функция возвращает изображение в зависимости от класса адреса
        /// </summary>
        /// <param name="MacClass">Класс адреса в текстовом виде</param>
        /// <returns></returns>
        private Image GetImageTypeForMacClass (String MacClass)
        {
            Image broadcast = Properties.Resources.broadcast;
            Image multicast = Properties.Resources.multicast;
            Image device = Properties.Resources.device;


            //В зависимости от класса возвращаем картинку
            switch (MacClass)
            {
                case "Широковещательный":
                    return broadcast;
                case "Групповой":
                    return multicast;
                case "Индивидуальный":
                    return device;
            }
            return null;
        }

        private async void LoadOUIList()
        {
            //Путь к файлу с OUI по стандарту IEEE
            String Path = "oui.txt";
            try
            {
               using (StreamReader sr = new StreamReader(Path))
                {
                    string line;
                    while ((line = await sr.ReadLineAsync()) != null)
                    {
                        if (line.Contains("(hex)"))
                        {
                            var pieces = (from piece in line.Split(new char[] { ' ', '\t' })
                                          where !string.IsNullOrEmpty(piece)
                                          select piece).ToArray();

                            for (int i = 1; i < pieces.Length; i++)
                            {
                                if (pieces[i] == "(hex)")
                                    pieces[i] = "";

                                else
                                    pieces[1] = pieces[1] + pieces[i];
                            }

                            OUIList.Add(new OUIInfo(pieces[0], pieces[1]));
                           

                        }
                    }
                }
                //Настройка интерфейса
                isOUILoaded = true;
                OUIStatus.Visible = false;
                buttonSendArp.Enabled = true;
                pictureLoading.Visible = false;
                
                
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить список OUI", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string GetVendor(string deviceMac)
        {
            string DeviceOUI = deviceMac.ToUpper().Substring(0, 8);
            foreach (var vendor in OUIList)
            {
                
                if (DeviceOUI == vendor.Mac)
                {
                    return vendor.Vendor;
                }
            }
            return "Неизвестен";
        }


    }
}
