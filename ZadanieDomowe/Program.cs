using System;

namespace MagazynWina
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuActionService actionService = new MenuActionService();
            actionService = Initialize(actionService);
            WineService wineService = new WineService();
            Console.WriteLine("Welcom in my app");

            while (true)
            {

                Console.WriteLine("Tell me what you to do");

                var mainMenu = actionService.GetMenuActionsByMenuName("Main");

                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].ID}. {mainMenu[i].Name}");
                }

                var operation = Console.ReadKey();

                switch (operation.KeyChar)
                {
                    case '1':
                        var keyInfo = wineService.AddNewWineView(actionService);
                        var addId = wineService.AddNewWine(keyInfo.KeyChar);
                        break;

                    case '2':
                        var removeId = wineService.RemoveWineView();
                        wineService.RemoveWine(removeId);
                        break;

                    case '3':
                        var detailWineId = wineService.selectionWineDetail();
                        wineService.wineDetail(detailWineId);
                        break;

                    case '4':
                        var selectedTypeWine = wineService.selectionTypeWineDetail();
                        wineService.selectedTypeWinesDetail(selectedTypeWine);
                        break;


                    case '5':
                        wineService.SugarAdd();
                        break;

                    default:
                        Console.WriteLine("\nWrong action you entered");
                        break;
                }    
            }
        }
        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add new wine", "Main");
            actionService.AddNewAction(2, "Remove wine", "Main");
            actionService.AddNewAction(3, "Show details wine", "Main");
            actionService.AddNewAction(4, "List of wine", "Main");
            actionService.AddNewAction(5, "How much sugar add for starting producing wine", "Main");
            actionService.AddNewAction(7, "Exit Program", "Main");

            actionService.AddNewAction(1, "Sweet", "AddNewWineMenu");
            actionService.AddNewAction(2, "Half sweet", "AddNewWineMenu");
            actionService.AddNewAction(3, "Dry", "AddNewWineMenu");
            return actionService;
        }
    }
}