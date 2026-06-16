using HarmonyLib;
using Kingmaker.Blueprints.Items.Equipment;
using Kingmaker.Blueprints.JsonSystem;
using System.Reflection;
using UnityModManagerNet;

namespace RTReusableItems;

public static class Main
{
    internal static Harmony HarmonyInstance;
    internal static UnityModManager.ModEntry.ModLogger Log;

    public static bool Load(UnityModManager.ModEntry modEntry)
    {
        Log = modEntry.Logger;
        modEntry.OnGUI = OnGUI;
        HarmonyInstance = new Harmony(modEntry.Info.Id);
        try
        {
            HarmonyInstance.PatchAll(Assembly.GetExecutingAssembly());
        }
        catch
        {
            HarmonyInstance.UnpatchAll(HarmonyInstance.Id);
            throw;
        }
        return true;
    }

    public static void OnGUI(UnityModManager.ModEntry modEntry)
    {

    }

    [HarmonyPatch(typeof(BlueprintsCache))]
    public static class BlueprintsCaches_Patch
    {
        private static bool Initialized = false;

        [HarmonyPriority(Priority.First)]
        [HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
        public static void Init_Postfix(BlueprintsCache __instance)
        {
            try
            {
                if (Initialized)
                {
                    Log.Log("Already initialized blueprints cache.");
                    return;
                }
                Initialized = true;

                Log.Log("Patching blueprints.");
                String[] guids = [
                    "82bec0310585476ca65f4f109557557c",
                    "2b0849365c3c486e92bbb5660fbf051b",
                    "54861008f02e4c63b3ae474312097cf3",
                    "b074d60ee4fc406ba88e113f0cd2ce3a",
                    "02e3fe7902f04c2f8bac7c9b15abd8ae",
                    "6089683abf7f4599b5f3a008ea99f724",
                    "3194d57e8c404ef68414338ae7af1870",
                    "7d3001156fec8ce499be74f5476140a4",
                    "a8ababfbf25049d8ae884bcb82525b0a",
                    "07e75586610848e7a942c29e51ba5fa5",
                    "d8877770478c4a3ea9b64fafee7abd36",
                    "ad4d37b8a1a24666af16f2b9fa09eae6",
                    "3036632a9eb34c8093837ce67a3b9870",
                    "1843de0c31ca4c5c94b45cf87ff0a41e",
                    "cc0b722f380541d89ac15d42290fa5ec",
                    "5e648013406f49c5878e7733c55ee105",
                    "4241a581631a41938cf45911cdae6cc7",
                    "9699621372aa4c3aa4df6b4a1f116db0",
                    "877f47130a2d43a3aa943dc847dc9235",
                    "b6daa597bb6b5114bb9e21ea1e855792",
                    "c0597f96f77042b4a705aafaf01b76ec",
                    "775c0ff036cc40c295168126ba0137c4",
                    "58d3b2e71d5245aab60cfe026e3e2343",
                    "79b1f8fa1fb9463cbb50e00979a9c1f4",
                    "16ccfa01deb148c1a0cee796fe5ea295",
                    "17d042939e73b2a42918e8ff1d931103",
                    "de5bd3fa3ba642208ede17ed3827e29e",
                    "7d804b9e661a4fbdb4138c9de4808dda",
                    "70cef1cfff5d4c91affe098d80ed57b5",
                    "3a4eebf212974ba68d6867981c240b1b",
                    "ece61084f54a452cb63c135dab7c2b0f",
                    "9a7233892a414a52a5cd4fb4367a5d99",
                    "a93a71bcb8904f30891a4710af6be8e7",
                    "9637dc3883074c6ca17bb0ba6bee8605",
                    "0088d2c1ea084c1428266b7ffdeb6ab1",
                    "60b61f9c46374afdb76abc9d2f654328",
                    "633143bfc45945e18d0f275c544d82c4",
                    "848349b5906149f2b7dcf599a3b0d87b",
                    "46b2115431f4432699b005ffbf55debc",
                    "66a395add85649daab0b40484c72e05f",
                    "a87ea3a714c045f4b27072ea1de37a98",
                    "de7ae5185beb489d9981610afd033333",
                    "ba6c9b3434a740a08a0a28ef24dceb3d",
                    "d089cc4d4d194b85bd3614a855c45f7b",
                    "20650117b63acf740998b602e108c51a",
                    "e129ac75f5c84ee0b9bbbe584f99a518",
                    "f1b22d8810584b1dae358df1b94cfbcd",
                    "cce8ef29541447d9828dff015136a123",
                    "55964fecf2264a82820365dd0f07eb7b",
                    "947fb06dcd65411e8d991e9987f1f184",
                    "292221b9b73f487c9299393c537602be",
                    "f136b6d2fff34dc8986dea65d452cfed",
                    "583b587520c14c04b86f7b2277dac4e2",
                    "a7a3c48f88be440c80a25d4eb259a1b9",
                    "78a3db775b8e4926903e82267a901efb",
                    "bf44c827c9cb4d47a0027b02f70dfac7",
                    "d401266ba32b4fdbabb74fb006c638a1",
                    "bfefa111dd4a4913a95f887df2b5d948",
                    "e397cb9f6a1140a3bd9108aa43dc2b16",
                    "53a441db74d4461396938c775513dee6",
                    "fba70f596450402f86d49e9c8cccea9e",
                    "f23cc7ce1cd84c55890c914a695fc9b5",
                    "d1e3d6c62bac4421844c33aaad5f99aa",
                    "705dcc9dda9d429e9de2c8f974e632b6",
                    "1c20a615e0f04591a467b8a62aea1996",
                    "dcaab7fe2ed24b8f8ebdecbd35433e57",
                    "8b784af230484a90ad801e901a9d0b8e",
                    "edf1ca959e0f40f4bf5bb64586f816b9",
                    "d878a044b9174fc7b663ba94b0aee377",
                    "5cb792047d8945f8beba608d6f8a828e",
                    "4158054f16214c129f2bca3167f892f6",
                    "cd2541b15c4249fd974c3a2a0695aa70",
                    "a676f7b14cf445159680c73184e2aaea",
                    "a1ef13863d0245c6956f84c46f105dcb",
                    "63c1e87c8502400f91537ee5e1fb8460",
                    "56e3576b84384495b9015d5ec88217ac",
                    "9c64cb49aadd41cb87a7ad563bd53d89",
                    "237e04a301754516933f0eeaabca75da",
                    "c47bb956bb7c40d990e49c97c89a4f6d",
                    "079db609bf0645e9af5b02192db4b530",
                    "0c9d46cdf46d45059fcabc22470b8d51",
                    "d37d8bc3ddbc4076b1c9fb9907ef02e8",
                    "8d9ec005c04a4984ad6032b3f74d84b1",
                    "62ac0bd029d44651b9af3272aa9cb858",
                    "28ac7aeca52d49ee87f689dd38ab7c1b",
                    "825880d91b2c4c3197305d733ecf59c2",
                    "deb6d03fc0084423974c66769bb7f4cd",
                    "e76770434ebb42cfa56f43d50af6b6ec",
                    "b91d1316ec56428ca72367d00371eb38",
                    "63163480808b4fb2932537c4e34b8eed",
                    "5cecaba1ed324f8091ba8f3bd73263c4",
                    "b75ea790316645d2adcbf29c67d6b9eb",
                    "9e15c7fd275e47c48311462f15d0f40e",
                    "a13998b7441d44698a6df041c9ae3436",
                    "0318041641ae4f72b2ada5f05e0b1f24",
                    "abf79ea6a0cf489fa4a93d452d98391e",
                    "5c8036d528b7492097160454d5ff3eda",
                    "d059472d00364f148c91a95ef724d493"];

                foreach (var guid in guids)
                {
                    BlueprintItemEquipmentUsable item = (BlueprintItemEquipmentUsable)__instance.Load(guid);
                    item.RemoveFromSlotWhenNoCharges = false;
                    item.RestoreChargesAfterCombat = true;
                }

                Log.Log("Done patching blueprints.");
            }
            catch (Exception e)
            {
                Log.Log(string.Concat("Failed to initialize.", e));
            }
        }
    }
}
