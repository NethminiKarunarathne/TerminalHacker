using UnityEngine;
using System.Collections;

public class Hacker : MonoBehaviour
{
    //Game State
    int level;
    enum Screen { MainMenue,Password,Win};
    Screen CurrentScreen;
    string password;
    const string menueHint = "You may enter menue at any time. Press Esc to Quit.";
    string[] Level1Passwords = {"books","aisle","shelf","password","font","borrow"};
    string[] Level2Passwords = {"prisoner","handcuffs","holster","uniform","arrest"};
    string[] Level3Passwords = {"startrek","blackhole","supernova","orayan","asterroid" };
    // Start is called before the first frame update
    
    void Start()
    {
        showMainMenue("Hello Nethmini,");
        
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    void showMainMenue(string greetings) 
    {
        Terminal.ClearScreen();
        CurrentScreen = Screen.MainMenue;
        Terminal.WriteLine(greetings);
       
        Terminal.WriteLine("What would you like to hack into?");
        Terminal.WriteLine("Press 1 for lacal library");
        Terminal.WriteLine("Press 2 for Police station");
        Terminal.WriteLine("Press 3 for NASA");
        Terminal.WriteLine("Enter your selection");
    }
    void OnUserInput(string input)
    {
        if (input == "menue")
        {
            showMainMenue("Hello again Pal");
        }
        else if(CurrentScreen == Screen.MainMenue)
        {
            RunMainMenue(input);
            
        }
        else if(CurrentScreen == Screen.Password)
        {
            checkPassword(input);
            
        }
       
    }
    void RunMainMenue(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            StartGame();
        }



        else if (input == "007")
        {
            Terminal.WriteLine("Read the instruction fake Bond!");
        }

        else
        {
            Terminal.WriteLine("Please select a valid Level");
            Terminal.WriteLine(menueHint);

        }   
            
        
    }
    void StartGame()
    {
        
        CurrentScreen = Screen.Password;
        Terminal.ClearScreen();

        SetRandomPassword();
        Terminal.WriteLine("Enter your Password. Hint: " + password.Anagram());
        Terminal.WriteLine(menueHint);
    }
    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:

                password = Level1Passwords[Random.Range(0, Level1Passwords.Length)];
                break;
            case 2:

                password = Level2Passwords[Random.Range(0, Level2Passwords.Length)];
                break;
            case 3:
                password = Level3Passwords[Random.Range(0, Level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
    }
    void checkPassword(string input)
    {
        if(password == input)
        {
            DisplayWinScreen();
            
        }
        else
        {
            StartGame();
        }
    }
    void DisplayWinScreen()
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine(menueHint);
        
    }
    void ShowLevelReward()
    {
        switch (level)
        {
            case 1:
                Terminal.WriteLine("Have a book....");
                Terminal.WriteLine(@"
    ________
   /       //
  /       //
 /_______// 
(_______(/ 
"               );
                break;
            case 2:
                Terminal.WriteLine("You've got a Gun!");
                Terminal.WriteLine(@"
_______________
|   __ ________|      
|  |__|  
|  |
|__|
"                );
                Terminal.WriteLine("Go to Level 3 for a better challenge");
                break;
            case 3:
                
                Terminal.WriteLine(@"
_    _  __   ___    __
| \  | /__\  |__   /__\
|  \_|/    \  __| /    \
");
                Terminal.WriteLine("Welcome to NASA's internal system!");
                break;
            default:
                Debug.LogError("Invalid level reached!");
                break;



        }

    }
    
    



}



