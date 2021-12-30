using CitizenFX.Core;
using CitizenFX.Core.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UKVehiclePlates
{
    public class UKVehiclePlates : BaseScript
    {

        private static Random _random = new Random();
        private static List<string> commonStartletters = new List<string> { "MA", "MB", "MC", "MD", "ME", "MF", "MG", "MH", "MJ", "MK", "ML", "MM", "MN", "MO", "MP", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY" };
        private static List<string> allStartletters = new List<string> { "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AR", "AS", "AT", "AU", "AV", "AW", "AX", "AY", "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BR", "BS", "BT", "BU", "BV", "BW", "BX", "BY", "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CR", "CS", "CT", "CU", "CV", "CW", "CX", "CY", "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DR", "DS", "DT", "DU", "DV", "DW", "DX", "DY", "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "ER", "ES", "ET", "EU", "EV", "EW", "EX", "EY", "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FJ", "FK", "FL", "FM", "FN", "FP", "FR", "FS", "FT", "FV", "FW", "FX", "FY", "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GR", "GS", "GT", "GU", "GV", "GX", "GY", "HA", "HB", "HC", "HD", "HE", "HF", "HG", "HH", "HJ", "HK", "HL", "HM", "HN", "HO", "HP", "HR", "HS", "HT", "HU", "HV", "HX", "HY", "HW", "KA", "KB", "KC", "KD", "KE", "KF", "KG", "KH", "KJ", "KK", "KL", "KM", "KN", "KO", "KP", "KR", "KS", "KT", "KU", "KV", "KW", "KX", "KY", "LA", "LB", "LC", "LD", "LE", "LF", "LG", "LH", "LJ", "LK", "LL", "LM", "LN", "LO", "LP", "LR", "LS", "LT", "LU", "LV", "LW", "LX", "LY", "MA", "MB", "MC", "MD", "ME", "MF", "MG", "MH", "MJ", "MK", "ML", "MM", "MN", "MO", "MP", "MR", "MS", "MT", "MU", "MV", "MW", "MX", "MY", "NA", "NB", "NC", "ND", "NE", "NF", "NG", "NH", "NJ", "NK", "NL", "NM", "NN", "NO", "NP", "NR", "NS", "NT", "NU", "NV", "NW", "NX", "NY", "OA", "OB", "OC", "OD", "OE", "OF", "OG", "OH", "OJ", "OK", "OL", "OM", "ON", "OO", "OP", "OR", "OS", "OT", "OU", "OV", "OW", "OX", "OY", "PA", "PB", "PC", "PD", "PE", "PF", "PG", "PH", "PJ", "PK", "PL", "PM", "PN", "PO", "PP", "PR", "PS", "PT", "PU", "PV", "PW", "PX", "PY", "RA", "RB", "RC", "RD", "RE", "RF", "RG", "RH", "RJ", "RK", "RL", "RM", "RN", "RO", "RP", "RR", "RS", "RT", "RU", "RV", "RW", "RX", "RY", "SA", "SB", "SC", "SD", "SE", "SF", "SG", "SH", "SJ", "SK", "SL", "SM", "SN", "SO", "SP", "SR", "SS", "ST", "SU", "SV", "SW", "SX", "SY", "VA", "VB", "VC", "VD", "VE", "VF", "VG", "VH", "VJ", "VK", "VL", "VM", "VN", "VO", "VP", "VR", "VS", "VT", "VU", "VV", "VW", "VX", "VY", "WA", "WB", "WC", "WD", "WE", "WF", "WG", "WH", "WJ", "WK", "WL", "WM", "WN", "WO", "WP", "WR", "WS", "WT", "WU", "WV", "WW", "WX", "WY", "YA", "YB", "YC", "YD", "YE", "YF", "YG", "YH", "YJ", "YK", "YL", "YM", "YN", "YO", "YP", "YR", "YS", "YT", "YU", "YV", "YW", "YX", "YY" };
        private static List<string> firstNumber = new List<string> { "1", "6" };
        private static List<string> secondNumber = new List<string> { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        private static char[] lets = "ABCDEFGHJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static List<VehicleClass> blacklistedClasstypes = new List<VehicleClass> { VehicleClass.Boats, VehicleClass.Cycles, VehicleClass.Helicopters, VehicleClass.Planes, VehicleClass.Trains };

        public static char GetValidLetter()
        {
            return lets[_random.Next(lets.Length)];
        }

        public UKVehiclePlates()
        {
            Main();
        }

        public async void Main()
        {
            while (true)
            {
                await Delay(1000);
                Vehicle[] vehicles = World.GetAllVehicles();

                foreach (Vehicle veh in vehicles)
                {
                    await Delay(1);
                    if (veh != null && veh.Exists() && !blacklistedClasstypes.Contains(veh.ClassType) && !veh.PreviouslyOwnedByPlayer && (veh.Driver == null || !veh.Driver.Exists() || !veh.Driver.IsPlayer))
                    {
                        string plate = API.GetVehicleNumberPlateText(veh.Handle);
                        if (plate.Length > 1 && plate.Length != 8 || !char.IsLetter(plate[0]) || !char.IsLetter(plate[1]) || !char.IsDigit(plate[2]) || !char.IsDigit(plate[3]) || plate[4] != ' ' || !char.IsLetter(plate[5]) 
                            || !char.IsLetter(plate[6]) || !char.IsLetter(plate[7])) 
                        {
                            // Make it a UK plate
                            string newplate = "";
                            if (_random.Next(100) < 40)
                            {
                                newplate += commonStartletters[_random.Next(commonStartletters.Count)];
                            } else
                            {
                                newplate += allStartletters[_random.Next(allStartletters.Count)];
                            }

                            newplate += firstNumber[_random.Next(firstNumber.Count)];
                            newplate += secondNumber[_random.Next(secondNumber.Count)];

                            newplate += " " + GetValidLetter() + GetValidLetter() + GetValidLetter();
                            API.SetVehicleNumberPlateText(veh.Handle, newplate);
                        }
                    }
                }
            }
        }
    }
}
