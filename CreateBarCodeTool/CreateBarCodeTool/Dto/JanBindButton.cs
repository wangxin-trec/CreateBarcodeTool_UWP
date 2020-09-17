using Windows.UI.Xaml.Controls;

namespace CreateBarCodeTool.Dto {
    class JanBindButton {
        private string janCode;
        private Button button;
        private string dbCol;

        public JanBindButton(string janCode, Button button, string dbCol) {
            this.janCode = janCode;
            this.button = button;
            this.dbCol = dbCol;
        }

        public string getJanCode() {
            return this.janCode;
        }

        public Button getButton() {
            return this.button;
        }

        public string getDbCol() {
            return this.dbCol;
        }
    }
}
