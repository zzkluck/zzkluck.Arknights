using System.IO;
using System.Text.Json;
using Zzkluck.Arknights.Library.AkdataObject;

string akdataRoot = @"C:\Users\zzPC\Desktop\ArknightsGameData-master\zh_CN\gamedata";
string enemyDataBasePath = @".\levels\enemydata\enemy_database.json";
string levelPath = @".\levels";
string characterTablePath = @".\excel\character_table.json";
string skillTablePath = @".\excel\skill_table.json";
string handbookPath = @".\excel\fake_handbook.json";
string sampleOutputPath = @"C:\Users\zzPc\Desktop\1.txt";

var hhh = JsonFileObjectParser.Parse<HandbookObject>
                (File.ReadAllText(akdataRoot + handbookPath));
