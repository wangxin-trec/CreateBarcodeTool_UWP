using CreateBarCodeTool.Utils;
using SQLitePCL;
using System;

namespace CreateBarCodeTool.Utils {
    class DataBaseUtil {

        private SQLiteConnection conn;
        private static string DATABASE_NAME = "barcodeBase.db";
        private static string SQL_CREATE_TABLE = "create table if not exists " + BarcodeDBSchema.BarcodeTable.NAME +
                "(" +
                    BarcodeDBSchema.BarcodeTable.Cols.TESTONE + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.TESTTWO + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.TESTTHREE + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.TESTFOUR + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.TESTFIVE + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.TESTSIX + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.TESTSEVEN + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.TESTEIGHT + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.TESTNINE + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.TWOFIVEJAN + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.TWENTYFORBIDDEN + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.DRUG + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.SECURITY + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.DISCOUNT + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.HEAD0 + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.POSA + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.MARUKYU + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.TAMARU + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.BRANDSWITCH + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.TIMESCOUPON + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.PERIOD + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.CAMPAIN + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.BAG + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.ZEROPRICE + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.GATE + "," +
                    BarcodeDBSchema.BarcodeTable.Cols.STAFF +
                ")";

        private static string SQL_QUERY_TABLE_COUNT = "select count(*) from " + BarcodeDBSchema.BarcodeTable.NAME;

        private static string SQL_INSERT_TABLE = "insert into " + BarcodeDBSchema.BarcodeTable.NAME +
                        " (" +
                            BarcodeDBSchema.BarcodeTable.Cols.TESTONE + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.TESTTWO + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.TESTTHREE + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.TESTFOUR + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.TESTFIVE + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.TESTSIX + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.TESTSEVEN + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.TESTEIGHT + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.TESTNINE + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.TWOFIVEJAN + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.TWENTYFORBIDDEN + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.DRUG + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.SECURITY + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.DISCOUNT + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.HEAD0 + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.POSA + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.MARUKYU + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.TAMARU + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.BRANDSWITCH + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.TIMESCOUPON + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.PERIOD + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.CAMPAIN + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.BAG + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.ZEROPRICE + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.GATE + "," +
                            BarcodeDBSchema.BarcodeTable.Cols.STAFF +
                        ") values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

        private static DataBaseUtil singleton;

        public static DataBaseUtil getSingleton() {
            if (singleton == null) {
                singleton = new DataBaseUtil();
            }
            return singleton;
        }

        private DataBaseUtil() {
            this.conn = new SQLiteConnection(DATABASE_NAME);
        }

        public SQLiteConnection getDBconnect() {
            return this.conn;
        }

        public void createTable() {
            this.conn.Prepare(SQL_CREATE_TABLE).Step();
        }

        public bool isTableDataExists() {
            bool result = false;
            using (var statement = this.conn.Prepare(SQL_QUERY_TABLE_COUNT)) {
                SQLiteResult sqliteResult = statement.Step();
                if (SQLiteResult.ROW == sqliteResult) {
                    result = (Int64)statement[0] > 0 ? true : false;
                }
            }
            return result;
        }

        public void initTable() {
            using (var statement = this.conn.Prepare(SQL_INSERT_TABLE)) {
                statement.Bind(1, "2960000000012");
                statement.Bind(2, "2960000000029");
                statement.Bind(3, "2960000000036");
                statement.Bind(4, "2960000000047");
                statement.Bind(5, "2960000000050");
                statement.Bind(6, "2960000000067");
                statement.Bind(7, "2960000000074");
                statement.Bind(8, "2960000000081");
                statement.Bind(9, "2960000000098");
                statement.Bind(10, "2531446000999");
                statement.Bind(11, "4902210170510");
                statement.Bind(12, "4987774264288");
                statement.Bind(13, "4972940601189");
                statement.Bind(14, "25000010279001000302");
                statement.Bind(15, "080686816072");
                statement.Bind(16, "45802958260810006375028312416600");
                statement.Bind(17, "7130207110001939");
                statement.Bind(18, "4522646331332");
                statement.Bind(19, "4902388057026");
                statement.Bind(20, "4522646735680");
                statement.Bind(21, "4930726000175");
                statement.Bind(22, "4902102077354");
                statement.Bind(23, "4522646330991");
                statement.Bind(24, "4908819933402");
                statement.Bind(25, "000000010061");
                statement.Bind(26, "2000100764206");
                statement.Step();
            }
        }

        public string queryJanFromDB(string colName) {
            string result = "";
            using (var statement = this.conn.Prepare("select " + colName + " from " + BarcodeDBSchema.BarcodeTable.NAME)) {
                SQLiteResult sqliteResult = statement.Step();
                if (SQLiteResult.ROW == sqliteResult) {
                    result = statement[0] as string;
                }
            }
            return result;
        }

        public void updateJanCode(string colName,string janCode) {
            using (var statement = this.conn.Prepare("update " + BarcodeDBSchema.BarcodeTable.NAME + " set " + colName + " = ?")) {
                statement.Bind(1, janCode);
                SQLiteResult sqliteResult = statement.Step();
            }
        }
    }
}
