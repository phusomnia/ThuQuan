using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.FakeModels;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class AdminPanelForm : Form
    {
        public List<VatDung> vd = new List<VatDung>();
        public List<LoaiVatDung> lvd = new List<LoaiVatDung>();
        public Dictionary<string, int> LoaiVatDungDict = new Dictionary<string, int>();
        
        public AdminPanelForm()
        {
            // Fake data
            VatDung[] vd = new VatDung[]
            {
                new VatDung { Id = 1, TenVatDung = "Microwave Oven" },
                new VatDung { Id = 2, TenVatDung = "Refrigerator" },
                new VatDung { Id = 3, TenVatDung = "Air Conditioner" },
                new VatDung { Id = 4, TenVatDung = "Washing Machine" },
                new VatDung { Id = 5, TenVatDung = "Vacuum Cleaner" },
                new VatDung { Id = 6, TenVatDung = "Dishwasher" },
                new VatDung { Id = 7, TenVatDung = "Electric Kettle" },
                new VatDung { Id = 8, TenVatDung = "Toaster" },
                new VatDung { Id = 9, TenVatDung = "Blender" },
                new VatDung { Id = 10, TenVatDung = "Coffee Maker" }
            };
            foreach (var item in vd)
            {
                this.vd.Add(item);
            }

            LoaiVatDung[] lvd = new LoaiVatDung[]
            {
                new LoaiVatDung { Id = 1, TenLoai = "Loai 1" },
                new LoaiVatDung { Id = 2, TenLoai = "Loai 2" }
            };
            foreach (var item in lvd)
            {
                this.lvd.Add(item);
            }
            
            // 
            InitializeComponent();
            HideTabs();
            
            // Handle sub menu
            handleSubMenu(btnQuanLyPhieu, SubMenuQuanLyPhieu);
            handleSubMenu(btnQuanLyTaiKhoan, SubMenuQuanLyTaiKhoan);
            
            // handle route page
            handleRoutePage();

            handleUploadButton();
            handleCRUDPanel(VatDung_InsertBtn, VatDung_ExitBtn, null,null, VatDungInputPanel);
            handleButtonEvent(VatDung_SaveBtn);
            /*
             * TODO:
             * GET Loai Vat Dung -> Lưu data vào list hoặc tương tự
             * flow 1: chọn loại vật dụng -> sau nó nhấn lưu
             * flow 2: ghi loại vật dụng -> ấn enter
             *      con 1: nếu loại vật dụng ko ton tại -> thêm vào db
             *      con 2: nếu loại vật dụng ton tại -> showMessageBox("Loai vat dung nay da ton tai");
             */
            handleComboxEvent(cBLoaiVatDung);

            BindVatDungToDataGridView();
        }
        
        private void BindVatDungToDataGridView()
        {
            // Set the DataSource of the DataGridView to the vd list
            BangVatDung.DataSource = vd;
        }
        
        private void HideTabs()
        {
            PageLayouts.Appearance = TabAppearance.FlatButtons;
            PageLayouts.ItemSize = new Size(0, 1);
            PageLayouts.SizeMode = TabSizeMode.Fixed;
        }
        
        private void PageLayouts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = PageLayouts.SelectedIndex;
            Console.WriteLine("Tab changed to index: " + selectedIndex);
            // Add any additional logic you need when the tab changes
        }

        private void handleSubMenu(Button button, Panel panel)
        {
            var (isSubMenuVisible, setSubMenuVisibility) = useState(false);
            
            panel.Visible = isSubMenuVisible();

            button.Click += (sender, e) =>
            {
                setSubMenuVisibility(!isSubMenuVisible());
                panel.Visible = isSubMenuVisible();
                Console.WriteLine("Click!!!");
            };
        }

        private void handleRoutePage()
        {
            VatDungNavigation.Click += (sender, e) => { PageLayouts.SelectedIndex = 0;};
            PhieuMuonNavigation.Click += (sender, e) => { PageLayouts.SelectedIndex = 1; };
        }

        private void handleCRUDPanel(
            Button addButton, 
            Button exitButton,
            Button? updateButton,
            Button? lockButton,
            Panel panel)
        {
            var (isInputPanelVisible, setInputPanelVisibility) = useState(false);
            var (isViewPanelVisible, setViewPanelVisibility) = useState(true);
            panel.Visible = isInputPanelVisible();
            addButton.Visible = isViewPanelVisible();

            addButton.Click += (sender, e) =>
            {
                setInputPanelVisibility(!isInputPanelVisible());
                panel.Visible = isViewPanelVisible();
                
                setViewPanelVisibility(!isViewPanelVisible());
                addButton.Visible = isViewPanelVisible();
            };
            
            exitButton.Click += (sender, e) =>
            {
                setInputPanelVisibility(!isInputPanelVisible());
                panel.Visible = isViewPanelVisible();
                
                setViewPanelVisibility(!isViewPanelVisible());
                addButton.Visible = isViewPanelVisible();
                clearForm();
            };
        }


        private void handleUploadButton()
        {
            VatDung_UploadBtn.Click += (sender, e) =>
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Extract and display the file name
                    string fileName = Path.GetFileName(dialog.FileName);
                    Console.WriteLine("Selected image file name: " + fileName);

                    // Load the image into the PictureBox
                    pictureBox2.Image = Image.FromFile(dialog.FileName);
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                Console.WriteLine("Upload button clicked");
            };
            
            VatDung_ClearImgBtn.Click += (sender, e) =>
            {
                pictureBox2.Image = null;
                Console.WriteLine("Clear button clicked");
            };
        }

        private void handleComboxEvent(ComboBox comboBox)
        {
            foreach (var item in lvd)
            {
                LoaiVatDungDict.Add(item.TenLoai, item.Id);
            }
            
            // Fake insert data to comboBox
            foreach (var v in LoaiVatDungDict)
            {
                comboBox.Items.Add(v.Key);
            }
            
            comboBox.SelectedIndexChanged += (sender, e) =>
            {
                var selectedId = LoaiVatDungDict[comboBox.SelectedItem.ToString()];
                Console.WriteLine("Selected id: " + selectedId);
            };
        }

        private void handleButtonEvent(Button button)
        {
            if (button.Name.Contains("Insert"))
            {
                button.Click += (sender, e) =>
                {
                    VatDung VatDungDTO = new VatDung
                    {
                        TenVatDung = txtTenVatDung.Text,
                    };
                    ValidateForm(VatDungDTO);
                    Console.WriteLine("Insert button clicked");
                };
            }
        }

        private (Func<T>, Action<T>) useState<T>(T initialState)
        {
            // init state
            T state = initialState;
            
            // return current value of state
            Func<T> getState = () => state;
            
            //  
            Action<T> setState = (newState) =>
            {
                state = newState;
            };

            return (getState, setState);
        }
        
        private void LogCollection<T>(List<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private void clearForm()
        {
            txtTenVatDung.Clear();
            cBLoaiVatDung.SelectedIndex = 0;
        }

        private void ValidateForm(object obj)
        {
            ValidationContext context = new ValidationContext(obj, null, null);
            IList<ValidationResult> errors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(obj, context, errors, validateAllProperties: true))
            {
                foreach (ValidationResult error in errors)
                {
                    MessageBox.Show(error.ErrorMessage);
                }
            }
        }
    }
}