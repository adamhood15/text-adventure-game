class Enemy
{
    public string enemyName;
    public int enemyHealth;
    Random numberGen = new Random();
    public int damageRoll = 0;
    public int healSlots;
    public int hitRoll = 0;
    

    public Enemy(string _enemyName, int _enemyHealth, int _enemyAP, int _healSlots)
    {
        enemyName = _enemyName;
        enemyHealth = _enemyHealth;
        healSlots = _healSlots;
        hitRoll = 0;
        damageRoll = 0;
    }

    public void BasicAttack()
    {
        Console.WriteLine(enemyName + " draws their weapon and swings it at you as quickly as it can. \n");
        damageRoll = numberGen.Next(0, 3);
        if (damageRoll > 0)
        {
            Console.WriteLine(enemyName + " hits you with a Quick Strike and causes " + damageRoll + " damage.");
        }
        else 
        {
            Console.WriteLine("Unfortunately they swing a little too fast and miss you completely. ");
        }
    }

    public void StrongAttack()
    {
        hitRoll = numberGen.Next(0, 20);
        if (hitRoll >0)
        {
            damageRoll = numberGen.Next(4, 8);
            Console.WriteLine(enemyName + " swings at you with all it's might and causes" + damageRoll + " damage.\n");
        }
        else{Console.WriteLine(enemyName + " swings at you with all it's might and causes 1,000 damage!\nI'm just kidding, " + enemyName + " missed.");}

    }

    public void droidHeal()
    {
        Console.WriteLine(enemyName + " assesses damage and begins to repair itself. \n");
        enemyHealth += 2;
        Console.WriteLine(enemyName + " gains 2 HP.");
    }

  


}

class Jedi
{
            public string jediName;
            public string saberColor;
            int jediRank01;
            public int playerHealth = 0;
            public int maxPlayerHealth = 10;
            public int attackPoints = 0;
            public int maxAttackPoints = 5;
            public int defensePoints = 0;
            public int maxDefensePoints = 3;
            public float experience = 0.0f;
            public int level = 1;
            public int forceSlots = 0;
            public int forcePoints = 0;
            public int maxForcePoints = 5;
            public int damage = 0;
            Random playerNG = new Random();
            public int damageRoll;
            public int hitRoll;
                   

            public Jedi(string _jediName, string _saberColor)
            {
                jediName = _jediName;
                saberColor = _saberColor;
                forceSlots = 2;
                playerHealth = maxPlayerHealth;
                attackPoints = maxAttackPoints;
                forcePoints = maxForcePoints; 
                defensePoints = maxDefensePoints;
                damageRoll = 0;
                hitRoll = 0;
            }

            //Combat Methods
             public void BasicAttack()
                {
                    hitRoll = playerNG.Next(0, 10);
                    damageRoll = playerNG.Next(3, 4);
                    attackPoints -=1;

                    if (hitRoll >0)
                    {
                    Console.WriteLine(jediName + " ignites their " + saberColor + " lightsaber and slashes their enemy with a quick side swipe. *makes lightsaber sounds with mouth*\nYou deal " + damageRoll + " damage to your enemy.");
                    experience+= 0.2f;
                    }
                    else
                    {
                        Console.WriteLine(jediName + " missed their attack! You should try harder. \n");
                    }
                    
                }
                
                public void StrongAttack()
                {
                    if (attackPoints > 1)
                    {
                        hitRoll = playerNG.Next(0, 20);
                
                        if (hitRoll > 0)
                        {
                            damageRoll = playerNG.Next(5, 8);
                            Console.WriteLine("\n" + jediName + " ignites their " + saberColor + " lightsaber and cuts their enemy with a long winding downward slash. Eat Bantha Poodoo! You caused " +damageRoll + " damage.\n");
                            experience+= 0.2f;
                            attackPoints -=2;
                        }
                        else 
                        {
                            Console.WriteLine("\nOooooh, looks like you missed, you'll get 'em next time.\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("You don't have enought Action Points for that action. Are you even looking at the Battle Info section?\n");
                    }
                }

                public void ForcePush()
                {
                    if (forcePoints > 1)
                    {
                        damageRoll = playerNG.Next(1, 3);
                        Console.WriteLine(jediName + " feels the force draw within their body and release it with a powerful thrust. This pushes your enemy to the ground and causes  " + damageRoll + " damage.\n");
                        forcePoints -= 1;
                        experience += 0.2f;
                    }
                    else 
                    {
                        Console.WriteLine("You don't have enough Attack Points for that action. Are you even looking at the Battle Info section?\n");
                    }
                }

                public void ForceHeal()
                {
                     if (forcePoints > 1)
                    {
                        Console.WriteLine(jediName + " allows the force to flow inward and heal your wounds. Mmmm tingly.\n");
                        forcePoints-= 2;
                        if (playerHealth < 6)
                        {
                            playerHealth += 5;
                        }
                        else if (playerHealth > 6)
                        {
                            playerHealth = maxPlayerHealth;
                        }
                            
                        experience+= 0.2f;
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough Force Points for that action. Are you even looking at the Battle Info section?\n");
                    }
                    
                }

                public void Guard()
                {
                    if (defensePoints > 0)
                    {
                        defensePoints --;
                        Console.WriteLine(jediName + " prepares to defend against the enemy. \n");
                    }
                    else
                    {
                        Console.WriteLine("You don't have enough Defense Points for that action. Are you even looking at the Battle Info section?\n");
                    }
                }

                public void Meditate()
                {
                    if (forcePoints < maxForcePoints)
                    {
                        Console.WriteLine(jediName + " closes their eyes and channels the force through them in order to restore their focus. ");
                        forcePoints = maxForcePoints;
                        Console.WriteLine("All FP's have been restored.");
                    }
                    else {Console.WriteLine("Your force points are already at the maximum value. \n");}
                    
                    if (attackPoints < maxAttackPoints)
                        {
                            attackPoints = maxAttackPoints;
                            Console.WriteLine("All AP's have been restored.\n");
                        }
                        else {Console.WriteLine("Your attack points are already at the maximum value.\n");}
                }

                
}

internal class Program
{
    private static void Main(string[] args)
    {
        bool guardChoice = false;
        bool strongAttack = false;
        bool enemystrongAttack = false;
        int choiceRoll = 0;
        Random numberGen = new Random();

        Console.Title = "Star Wars Text Adventure";
        Console.WindowHeight = 60;
        Console.WindowWidth = 200;
        Jedi jedi01 = new Jedi("Adam", "Blue");
        

        //Combat Lists
        string[] PlayerAction =
        {
            "1. Basic Attack = 1 AP",
            "2. Strong Attack = 2 AP",
            "3. Force Push = 1 FP",
            "4. Guard = 1 DP",
            "5. Force Heal = 2 FP",
            "6. Meditate = Restore AP, and FP\n",
        };


        Console.ForegroundColor = ConsoleColor.Yellow;  
//Character Creator

        //Sex
         Console.WriteLine("Choose the sex of your Jedi (Type the number only) ");
    
            string[] sex =  {"1 Male", "2 Female"};
                for (int i = 0; i < sex.Length; i++)
                {Console.WriteLine(sex[i]);}
            
            int sex01 = Convert.ToInt32(Console.ReadLine());
                         switch (sex01)
                        {
                            case 1:
                                Console.WriteLine("\nAh, the old male savior complex, classic. I bet you think Chris Pratt would play you in a movie version of your life.");
                                break;

                            case 2:
                                Console.WriteLine("\nGirls just wanna have fun!");
                                break;

                          

                            default:
                                Console.WriteLine("Please type either 1, or 2.");
                                break;
                        }
                        
            
            Console.WriteLine("--------------------");
        //Name
            Console.WriteLine("Please enter your Jedi's first name only:\n ");
            jedi01.jediName = Console.ReadLine();
            Console.WriteLine("--------------------");
            Console.WriteLine("Veerrry original.\n");
            Console.ReadKey();
            Console.WriteLine("Welcome to the Rey 'Skywalker' Palpatine Jedi Temple " + jedi01.jediName + ".\n");
            Console.ReadKey();

        //Saber Color
            Console.WriteLine("What is the color of your lightsaber?\n");
            jedi01.saberColor = Console.ReadLine();
            Console.WriteLine("--------------------");
            Console.WriteLine("Predictable.\n");
            Console.ReadKey();

        //Power Level
        Console.WriteLine("Choose the power level of your Jedi:\n");
        Console.WriteLine("1 Padawan 2 Knight 3 Master\n");

            int rank = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("--------------------");

            switch (rank)
            {
                case 1:
                    Console.WriteLine("\nCongratulations on attaining the rank of Padawan! We're really not supposed to let older Jedi into the academy on account of the whole Anakin Skywalker becoming Darth Vader and plunging the galaxy into a few decades of darkness..... But I think we can make an exception for you!\n");
                    break;

                case 2:
                    Console.WriteLine("\nImprobable, you will be assigned the rank of Padawan");
                    break;

                case 3:
                    Console.WriteLine("\nAww, look at this little buddy, thinks their so strong. You will be assigned the rank of Padawan.");
                    break;


                default:
                    Console.WriteLine("Please select either 1, 2, or 3.");
                    break;
            }  
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n\n");
       
        Console.ReadKey();
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("Once upon a time in a galaxy far, far away...\n\n\n");
                Console.ReadKey();
                Console.WriteLine("Star Wars: Episode X: The Perfectly Okay Jedi\n\n\n");
                Console.ReadKey();
                Console.WriteLine("Peace reigns! Well....sort of.\n\n");
                Console.ReadKey();
                Console.WriteLine("The destruction of the evil dark lord clone, zombie or whatever they were trying to go for in Episode IX, Emperor Palpatine, has brought peace once more to the galaxy, or at least until Disney decided to milk out another trilogy.\n\n");
                Console.ReadKey();
                Console.WriteLine("The new Jedi Order that Rey 'Skywalker' (pending official documentation) Palpatine created and is now training a new generation of Jedi, and you're gonnna be one of them!\n\n");
                Console.ReadKey();
                Console.WriteLine("The only problem is, you lied on your application. You never quite understood how exactly the whole force thing works. You once tried to jedi mind trick some poor soul and ended up giving him brain damage. \n\n");
                Console.ReadKey();
                Console.WriteLine("Okay time to wrap this up. Anyway there's some kind of evil lord coming to destroy you, I forget his name. Anyway, have fun! Or not, I don't get paid enough to care.");
                Console.ReadKey();
                Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");

//Capter 1
        Console.ReadKey();
        Console.WriteLine("                                                                  Chapter 1\n\n\n");
        Console.ReadKey();
        Console.WriteLine("*whisper* Wake up " + jedi01.jediName + "......\n");
        Console.ReadKey();
        Console.WriteLine("*normal voice* " + jedi01.jediName + " you really should wake up.\n");
        Console.ReadKey();
        Console.WriteLine("*Yells* WAKE UP!!!!\n You're 10 minutes late to your lecture with Master Rey!\n");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("What would you like to wear to your first day of training? (Type in what you would like to wear)\n");
        Console.ForegroundColor = ConsoleColor.Blue;
        string clothes = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nHmm, not what I would wear but it's fine. You should do some laundry once the lessons are over though.\n");
        Console.ReadKey();
        Console.WriteLine("You throw on your best looking " + clothes + " and rush out the door in a mad dash, running as fast as you can bumping into droids, wookies, and any other cliche Star Wars thing you can think of.\n");
        Console.ReadKey();
        Console.WriteLine("You come to a screeching halt inside of the main hall and sit on the floor with about a dozen other Jedi of varying races. You see Rey at the front of the hall saying something about the Jedi Code when she stops abruptly and looks straight at you.\n");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Rey: Ah, nice of you to join us " + jedi01.jediName + ", what's the excuse for being late today?\n");
        
    //Dialogue Option 1
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("When given dialogue choices type in the number of the response that you hate the least. Each response has it's own reaction so choose wisely.\n");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("\n\n1 I'm so sorry Master Skywalker it won't happen again!\n2 We really should start these things later in the day.\n3 What the force is a holo alarm?");
            int choice01 = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;
                switch (choice01)
            {
                case 1:
                    Console.WriteLine("\nRey: That's what you said yesterday, and the day before that, and the day before that.");
                    break;

                case 2:
                    Console.WriteLine("\nRey: It's 2 o'clock in the afternoon, how much later do we need to start?");
                    break;

                case 3:
                    Console.WriteLine("\nRey (Sarcastically): Running late, and cracking jokes? Keep that up and you'll be a Jedi Knight in no time. \n");
                    break;


                default:
                    Console.WriteLine("Please type either 1, 2, or 3.");
                    break;
            }
                
                Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("\nYou instantly regret your choice of words as your face turns hot and flashes red with embarassment....but don't worry old sport, you probably won't get kicked out of the Jedi Academy by Master Skywalker...yet.\n");
        Console.ReadKey();
        Console.WriteLine("After completely dunking on you, Master Rey continues her lesson. She's sharing her personal insights into the power of the force but once you realize this lesson doesn't have anything to with actual fighting or unlimited power, you stop paying attention and instead begin to daydream about your old life.\n");
        Console.ReadKey();
        Console.WriteLine("You feel a sense of sadness and longing when you think about your family. Your mother was serious and quiet, but she never failed to show how much she loved you and your brothers. Your father was more playful and always made jokes that your mother didn't find very funny, but he too was devoted to your family and did all he could to protect you.\n");
        Console.ReadKey();

     //Friend Name
        Console.WriteLine("You are jolted back into reality when you feel your friend nudge you in your ribcage... You like your friend, you've only known them for a week but you share a bond that could be mistaken for that of lifelong friends. They are quiet, serious, and in no way would they ever think to crack a joke during one of Master Rey's lessons. Your friend's name is X0438@^%?PW but you always forget that the 38 is silent, so you made up a nickname for them.\n");    
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("(Type in your friends name)\n");
        string friend = Console.ReadLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n" + friend + ": You know, if you stopped watching that 2 Droids, 1 Wookie video over and over all night long, you might actually be able to get to class on time.\n");
    
    //Dialogue Option 2
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("1 Quit joking around, I could get expelled for something like that!  \n2. It's actually got a surprisingly great story. \n3 I'm watching it for the character development\n");

        int choice02 = Convert.ToInt32(Console.ReadLine());
        Console.ForegroundColor = ConsoleColor.Green;
            
            switch (choice02)
            {
                case 1:
                    Console.WriteLine("\n" + friend + ": *mockingly* 'I could get expelled for something like that!' \n");
                    break;

                case 2:
                    Console.WriteLine("\n" + friend + ": Yeah, wookie walks into a threesome with some droids, end of story.\n ");
                    break;

                case 3:
                    Console.WriteLine("\n" + friend + ": Develop deez nutzzzz\n");
                    break;

                default:
                    Console.WriteLine("Please type either 1, 2, or 3.");
                    break;
            }

        Console.ReadKey();
        Console.WriteLine("\n" + friend + ": You know, we're supposed to start our lightsaber training today right?! I can't wait to beat you down.\n ");

    //Dialogue Option 3    
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("1. A Jedi should never be excited to cause harm to others. \n2. Beat me down? More like.... I'll beat you down.\n3. Do you think Master Rey would let me hack off one of your limbs?\n ");
            int choice03 = Convert.ToInt32(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.Green;

            switch (choice02)
                        {
                            case 1:
                                Console.WriteLine(friend + ": Force almighty you are uptight. You should let loose once in a while.\n ");
                                break;

                            case 2:
                                Console.WriteLine(friend + ": You are truly the worst at comebacks. Don't worry I will teach you the ways of the comeback my young Padawan.\n");
                                break;

                            case 3:
                                Console.WriteLine(friend + ": Oooh I hope so. Hack off my hand so I can get one of those sweet robot hand!\n");
                                break;

                            default:
                                Console.WriteLine("Please type either 1, 2, or 3.");
                                break;
                        }
              
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("You and " + friend + " wait impatiently for Master Rey to finish her lecture when finally she dismisses the class for lightsaber training. Thank god, some action in this game!\n");
        Console.ReadKey();
        Console.WriteLine("You follow Master Rey and the group of students out of the main hallway into a large open courtyard with combat droids scattered throughout the area. Waiting in the center is a tall sleek Twilek with red skin whom you don't recognize.\n ");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(friend + ": Holy rancor, it's master Yondor! That guy is the most skilled lightsaber combatant in the whole galaxy, I heard that he even defeated Master Rey when he was her Padawan. \n\n");
        Console.ReadKey();
        Console.WriteLine("Rey: Everyone, I would like for you to meet your lightsaber combat instructor, Jedi Master Yondor. He will teach you everything there is to know about defending yourself with a lightsaber.\n\n");
        Console.ReadKey();
        Console.WriteLine("Yondor: Hello everyone, before we begin I just want to say a few words. When I was a young padawan...\n");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Narrator: Let's skip all this and go straight to the combat tutorial.\n\n ");
        Console.ReadKey();
        
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------\n\n");

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Yondor: Alright Padawans, ready yourselves for combat. \n");
        Console.ReadKey();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("You draw your lightsaber from your belt and ignite the brilliant " + jedi01.saberColor + " blade. You haven't decided how you want to hold your lightsaber yet so I guess let's pick that now. \n");
        Console.ReadKey();

    //Choice 4
        Console.WriteLine("Choose your lightsaber stance\n");    
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("1. Uhhh could you remind me what they are again? \n2. Yeaahhhh, I didn't actually read that part of the Jedi Text. \n3. Whatever the one Obi-Wan used? I just want to throw a peace sign above my head to strike fear into the hearts of my enemies.\n ");
            int choice04 = Convert.ToInt32(Console.ReadLine()); 
            Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Force almighty, you know what? You don't deserve to pick your own lightsaber form, you're just gonna be a basic bitch. I'm choosing Shii-Cho for you.\n");
        Console.ReadKey();
        Console.WriteLine("You hold your lightsaber close to your privates with both hands on the hilt. You're not quite sure if this is how you're supposed to do it but who cares.\n");
        Console.ReadKey();
        Console.WriteLine("You face the battle droid in front of you and ready yourself to make your first attack. \n");
        Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------------------------------");
        
        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
        Console.WriteLine("All combat in Star War X is turn based. I know, it totally blows but hey I'm just learning to code and this is the easiest thing I could think of.\n ");
        Console.ReadKey();
        Console.WriteLine("You have 4 different types of points to keep track of.\n\n1. Health Points keep you from not dying, lose all your health points and it's game over. \n2. Attack Points this allows you to smack a hoe. \n3. Force Points which you can use to make things get all floaty or heal yourself. \n4. Defense Points (only for babies)");
        Console.ReadKey();
        Console.WriteLine("Every turn you get to perform one of type of action. You either attack, defend, or recover.\n");
        Console.ReadKey();
        Console.WriteLine("Let's cover attacks first. Because let's face it, defending is suuuper lame. \n");
        Console.ReadKey();
        Console.WriteLine("You have three attacks to choose from.\n\n1. Basic Attack: This feels like your mom slapped you across your face for talking back in front of your friends(Normal damage). Costs 1 AP, and has a 10% chance to miss. \n2. Strong attacks feel like when your dad hits you for spilling his beer(Strong damage). Costs 2 AP, 5% chance to miss, and requires you to charge your attack for one turn before striking, leaving you vulnerable to attack. \n3. Force push throws your enemy to the ground just like your brother does when you call his girlfriend ugly (Weak damage). Costs 1 FP, but has a 100% chance to hit. \n");
        Console.ReadKey();
        Console.WriteLine("Now let's talk about the dumb baby stuff, defense.\n");
        Console.ReadKey();
        Console.WriteLine("You also have the choice of guarding against an enemy attack. This comes in handy if you're enemy is charging for a strong attack and you need to protect your cojones. Or if you're just \n");
        Console.ReadKey();
        Console.WriteLine("The last option is to recover. For this, you have two options.\n1. Meditate (Allows you to fully recover AP and FP and you look cool as hell doing it.)\n2. Force Heal (Do I really need to explain this one? Cost 3 FP)\n");
        Console.ReadKey();
        Console.WriteLine("After you perform an action, your enemy will do the same. You each continue to take turns until one of you bites the space dust.\n");
        Console.ReadKey();
        Console.WriteLine("Boy these jokes are bad, I really should let my wife write all the jokes. \n");
        Console.ReadKey();
        Console.WriteLine("Alright enough chit chat, let's get to the action. \n");
        Console.ReadKey();
        Console.WriteLine("Choose which action you would like to take first. \n");
        Console.ForegroundColor = ConsoleColor.Red;
        Enemy enemy01 = new Enemy("Droid Dummy", 10, 5, 1);

        Console.ForegroundColor = ConsoleColor.White;
        Console.ReadKey();
        Console.WriteLine("All combat in Star War X is turn based. I know, it totally blows but hey I'm just learning to code and this is the easiest thing I could think of.\n ");
        Console.ReadKey();
        Console.WriteLine("You have 4 different types of points to keep track of.\n\n1. Health Points (keeps you from not dying)\n2. Attack Points (allows you to slap a hoe)\n3. Force Points (rad as hell)\n4. Defense Points (only for babies)\n");
        Console.ReadKey();
        Console.WriteLine("Every turn you get to perform one of type of action. You either attack, defend, or recover.\n");
        Console.ReadKey();
        Console.WriteLine("Let's cover attacks first. Because let's face it, defending is kind of lame. \n");
        Console.ReadKey();
        Console.WriteLine("You have three attacks to choose from.\n\n1. Basic attacks feel like your mother slapped you in the face for talking back to her(Normal damage). (Costs 1 AP, 90% chance to hit)\n2. Strong attacks feel like your daddy hit you for spilling his beer can (Strong damage). They take two turns to complete and leave you vulnerable to an attack. (Costs 2 AP, 95% chance to hit)\n3. A Force Push is the only attack that is a guaranteed hit, it feels like if you were to try and hit your daddy in retaliation for him hitting you(Weak damage). (Costs 2 force points)\n");
        Console.ReadKey();
        Console.WriteLine("Now let's talk about the lame baby stuff, defending.\n");
        Console.ReadKey();
        Console.WriteLine("You also have the choice of guarding against an enemy attack. This comes in handy if you are about to be hit with a strong attack from your enemy or if you're just a big baby who doesn't like to get hit. This will negate all incoming damage for one turn. \n");
        Console.ReadKey();
        Console.WriteLine("The last option is to recover. For this, you have two options.\n1. Meditate allows you to fully recover AP and FP and you look cool as hell doing it, but leaves you vulnerable to attack. \n2. Force Heal (Do I really need to explain this one? Cost 2 FP, restores 5 HP)\n");
        Console.ReadKey();
        Console.WriteLine("After you perform an action, your enemy will do the same. You each continue to take turns until one of you bites the space dust.\n");
        Console.ReadKey();
        Console.WriteLine("Boy these jokes are bad, I really should let my wife write all the jokes. \n");
        Console.ReadKey();
        Console.WriteLine("Alright enough chit chat, let's get to the action. \n");
        Console.ReadKey();
        Console.WriteLine("Choose which action you would like to take first. \n");
//Combat Instance 1
        while (jedi01.playerHealth > 0 && enemy01.enemyHealth > 0)
        {
        //Player Turn
                Console.ReadKey();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("----------Battle Info---------- \n\n" + jedi01.jediName + "     HP: " + jedi01.playerHealth + "     AP: " + jedi01.attackPoints + "     FP: " + jedi01.forcePoints + "     DP: " + jedi01.defensePoints + "\n\n" + enemy01.enemyName + " HP: " + enemy01.enemyHealth + "\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n----- Player Turn -----\n");
                for (int i = 0; i < PlayerAction.Length; i++)
                {
                    Console.WriteLine(PlayerAction[i]);
                }

                int playerAction = Convert.ToInt32(Console.ReadLine());

                switch (playerAction)
                {
                    case 1:
                        jedi01.BasicAttack();
                        enemy01.enemyHealth -= jedi01.damageRoll;
                        break;
                    
                    case 2:
                        if (strongAttack == true)
                            {
                                jedi01.StrongAttack();
                                enemy01.enemyHealth -= jedi01.damageRoll;
                                strongAttack = false;
                            }
                        else
                            {
                                strongAttack = true;
                                Console.WriteLine(jedi01.jediName + " concentrates for a powerful strike. ");
                            }
                            break;
                        
                    case 3:
                        jedi01.ForcePush();
                        enemy01.enemyHealth -= jedi01.damageRoll;
                        break;

                    case 4:
                        guardChoice = true;
                        jedi01.Guard();
                        break;

                    case 5:
                        jedi01.ForceHeal();
                        break;

                    case 6:
                        jedi01.Meditate();
                        break;

                    default:
                    Console.WriteLine("Please type in a corresponding number for the action you would like to perform. ");
                    break;
                }  

 //Enemy Turn
                Console.ReadKey();
                if (enemy01.enemyHealth > 0)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("----------Battle Info---------- \n" + jedi01.jediName + "     HP: " + jedi01.playerHealth + "     AP: " + jedi01.attackPoints + "     FP: " + jedi01.forcePoints + "     DP: " + jedi01.defensePoints + "\n---\n" + enemy01.enemyName + " HP: " + enemy01.enemyHealth + "\n");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n----- Enemy Turn -----\n");
                
                    if (enemy01.enemyHealth > 1)
                    {
                        choiceRoll = numberGen.Next(-1, 1);
                        if (choiceRoll == 0)
                        {
                            if (guardChoice == true)
                            {
                                Console.WriteLine(enemy01.enemyName + " tries to attack but " + jedi01.jediName + " deflects with their lightsaber. \n");
                                jedi01.playerHealth -= 0; 
                                guardChoice = false;
                             }
                        else
                            {
                                enemy01.BasicAttack();
                                jedi01.playerHealth -= enemy01.damageRoll;
                            }
                        }
                        else
                        {
                            if (guardChoice == true)
                            {
                                Console.WriteLine(enemy01.enemyName + " tries to attack but " + jedi01.jediName + " deflects with their lightsaber. \n");
                                jedi01.playerHealth -= 0;
                                guardChoice = false;
                            }
                            else
                            {
                                if (enemystrongAttack == true)
                                {
                                    enemy01.StrongAttack();
                                    jedi01.playerHealth -= enemy01.damageRoll;
                                    enemystrongAttack = false;
                                }
                                else
                                {
                                    enemystrongAttack = true;
                                    Console.WriteLine(enemy01.enemyName + " concentrates for a powerful strike. ");
                                }   
                            }   
                        }
                        
                        
                    }
                    else if (enemy01.enemyHealth == 1)
                    {
                        enemy01.droidHeal();
                    }
                   
                }
                else
                {
                    Console.WriteLine("\nYou vanquished your enemy! That took a little longer than expected but good for you. \n");
                    jedi01.attackPoints = jedi01.maxAttackPoints;
                    jedi01.playerHealth = jedi01.maxPlayerHealth;
                    jedi01.forcePoints = jedi01.maxForcePoints;
                    jedi01.defensePoints = jedi01.maxDefensePoints;
                    Console.WriteLine("All attack, force, defense, and health points have been regenerated. \n--------------------------------------------------------------------------------------------");
                }
        }

    Console.ReadKey();    
    }
}
