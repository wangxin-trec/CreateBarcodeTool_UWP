namespace CreateBarCodeTool.Dto {
    class GlobalFlag {

        private string help = "";

        private static GlobalFlag singoton;

        private GlobalFlag() { }

        public static GlobalFlag getInstance() {
            if (singoton == null) {
                singoton = new GlobalFlag();
            }
            return singoton;
        }

        public void setHelp(string help) {
            this.help = help;
        }

        public string getHelp() {
            return this.help;
        }
    }
}
