Imports System.Threading
Imports System.Console
Module Module1
    Dim PlayerHealth As Integer

    Function RandomEncounter()
        Dim RandomValue As Integer
        Randomize()
        RandomValue = CInt(Math.Floor((10 - 1 + 1) * Rnd())) + 1
        Return RandomValue
    End Function

    Function Battle(PlayerRace As String, Location As Char, Weapon As Boolean)
        Dim PlayerChoice As Integer
        Dim TempPlayerChoice As String
        Dim PlayerDamage As Integer
        Dim MonsterDamage As Integer
        Dim MonsterHealth As Integer
        Dim Damage As Integer
        Dim Counter As Integer = 2
        Dim GameOver As Boolean
        Dim TurnFail As Boolean

        Select Case PlayerRace
            Case Is = "Elf", "elf"
                PlayerDamage = 4
            Case Is = "Man", "man"
                PlayerDamage = 6
            Case Is = "Giant", "giant"
                PlayerDamage = 7
            Case Is = "Dwarf", "dwarf"
                PlayerDamage = 6
        End Select

        Select Case Location
            Case Is = "C"
                MonsterDamage = 5
                MonsterHealth = 10
                CentreConsole("A bat-like creature flies down from the cave ceiling, launching itself to attack you but thankfully missing.")
            Case Is = "F"
                MonsterDamage = 7
                MonsterHealth = 15
                CentreConsole("You walk into a large sticky web. Whilst you're trying to brush it off a large spider with pale, bulbous eyes creeps down into your view.")
            Case Is = "M"
                MonsterDamage = 5
                MonsterHealth = 25
                CentreConsole("A large boulder narrowly avoids hitting you and you look up in shock to see a huge stone golem standing before you.")
            Case Is = "W"
                MonsterDamage = 7
                MonsterHealth = 25
                CentreConsole("A manticore paws along the cracked ground, it's scorpion tail rearing up to kill.")
            Case Is = "V"
                MonsterDamage = 10
                MonsterHealth = 6
                CentreConsole("The boy draws back the bow, ready to fight you.")
            Case Is = "D"
                MonsterDamage = 10
                MonsterHealth = 50
                CentreConsole("The wyvern roars it's challenge as you enter it's presence, it's all or nothing now.")
                If Weapon = True Then
                    MonsterHealth = MonsterHealth / 2
                End If
        End Select

        Do
            TurnFail = False
            Wait()
            CentreConsole("")
            CentreConsole("What do you do?")
            CentreConsole("1: Attack    2. Defend")
            CentreConsole("3. Magic     4. Run")
            TempPlayerChoice = ReadLine()
            Try
                PlayerChoice = CInt(TempPlayerChoice)
            Catch ex As Exception
                CentreConsole("You do know that you're meant to enter the number right? You must be confused.")
            End Try
            If PlayerChoice < 1 Or PlayerChoice > 4 Then
                CentreConsole("I don't know what you're trying to do here. You must be confused.")
            End If

            Select Case PlayerChoice
                    Case Is = 3
                        Select Case PlayerRace
                            Case Is = "Elf", "elf"
                            If Counter >= 2 Then
                                Wait()
                                CentreConsole("You launch a ball of fire through the air, slamming into the enemy.")
                                Damage = 8 + Math.Floor(RandomEncounter() / 3)
                                If Damage < 0 Then
                                    Damage = Damage * -1
                                End If
                                MonsterHealth = MonsterHealth - Damage
                                Counter = 0
                            Else
                                Wait()
                                CentreConsole("You can't use that again yet.")
                                TurnFail = True
                                End If
                            Case Is = "Man", "man"
                            If Counter >= 2 Then
                                Wait()
                                CentreConsole("You take stance and prepare to double the power of your next blow.")
                                Counter = 0
                            Else
                                Wait()
                                CentreConsole("You can't use that again yet.")
                                TurnFail = True
                                End If
                            Case Is = "Dwarf", "dwarf"
                            If Counter >= 2 Then
                                Wait()
                                CentreConsole("You toss a hammer at your enemy, injuring them.")
                                MonsterHealth = MonsterHealth - 8
                                Counter = 0
                            Else
                                Wait()
                                CentreConsole("You can't use that again yet.")
                                TurnFail = True
                                End If
                        Case Is = "Giant", "giant"
                            Wait()
                            CentreConsole("Giants cannot use magic.")
                            TurnFail = True
                        End Select

                    Case Is = 1
                        Damage = PlayerDamage + Math.Floor(RandomEncounter() / 3)
                        If Damage < 0 Then
                            Damage = Damage * -1
                        End If
                        If (PlayerRace = "Man" Or PlayerRace = "man") And Counter = 1 Then
                            Damage = Damage * 2
                        End If
                        MonsterHealth = MonsterHealth - Damage
                        Wait()
                    CentreConsole("You hit your enemy solidly, injuring them.")

                Case Is = 4
                        If Location = "D" Then
                            Wait()
                        CentreConsole("You cannot escape from the wyvern.")
                    Else
                            If RandomEncounter() < 4 Then
                                MonsterHealth = 0
                                Wait()
                            CentreConsole("You escape the battle successfully.")
                        Else
                                Wait()
                            CentreConsole("Your enemy blocks your path.")
                        End If
                        End If
                End Select

                If MonsterHealth >= 1 And TurnFail = False Then
                    Damage = MonsterDamage + Math.Floor(RandomEncounter() / 3)
                    If Damage < 0 Then
                        Damage = Damage * -1
                    End If
                    If PlayerChoice = 2 Then
                        If RandomEncounter() < 4 Then
                            Wait()
                        CentreConsole("You were ready for the enemy and so dodge their attack.")
                        Damage = 0
                        End If
                        Damage = Damage / 2
                    End If
                    PlayerHealth = PlayerHealth - Damage
                    If Damage <> 0 Then
                        Wait()
                    CentreConsole("Your enemy attacks you, injuring you.")
                End If
                End If
            Counter = Counter + 1

        Loop Until PlayerHealth < 1 Or MonsterHealth < 1

        If PlayerHealth < 1 Then
            Wait()
            CentreConsole("You have been defeated.")
            Wait()
            Write("GAME")
            Wait()
            CentreConsole(" OVER.")
            GameOver = True
        Else
            GameOver = False
            Select Case Location
                Case Is = "C"
                    Wait()
                    CentreConsole("You finish the bat-like creature with one fell swoop, stabbing and killing it before continuing through the caves.")
                Case Is = "F"
                    Wait()
                    CentreConsole("You crunch the spider beneath your feet, finally able to clean yourself of all of its web.")
                Case Is = "M"
                    Wait()
                    CentreConsole("The stone golem collapses at your feet, creating a miniature landslide which rolls down the mountain.")
                Case Is = "W"
                    Wait()
                    CentreConsole("You defeat the manticore, leaving another lifeless body to litter the wasteland. You pull the quills out of your front carefully, as you continue your journey in the blazing heat.")
                Case Is = "V"
                    Wait()
                    CentreConsole("You knock the boy unconscious with the hilt of your sword, taking the elven longbow from him.")
            End Select
            CentreConsole("")
        End If

        Return GameOver
    End Function

    Function Navigation(ByRef X As Integer, ByRef Y As Integer)
        Dim OldX As Integer
        Dim OldY As Integer
        Dim PlayerChoice As Char
        Dim ValidPlayerChoice As Boolean
        Dim Temp(1, 1) As Integer
        OldX = X
        OldY = Y

        Do
            CentreConsoleWrite("You can travel ")
            If Y + 1 <> 7 Then
                Write("North ")
            End If
            If Y - 1 <> 0 Then
                Write("and South ")
            End If
            If X + 1 <> 5 Then
                Write("and East ")
            End If
            If X - 1 <> 0 Then
                Write("and West")
            End If
            Write("")
            PlayerChoice = ReadLine()

            Select Case PlayerChoice
                Case "N", "n"
                    Y = Y + 1
                Case "S", "s"
                    Y = Y - 1
                Case "E", "e"
                    X = X + 1
                Case "W", "w"
                    X = X - 1
            End Select

            If X = 5 Or X = 0 Or Y = 0 Or Y = 7 Then
                X = OldX
                Y = OldY
                ValidPlayerChoice = False
                CentreConsole("You cannot go that way.")
            Else
                ValidPlayerChoice = True
            End If
        Loop Until ValidPlayerChoice = True
        Temp(1, 0) = X
        Temp(0, 1) = Y
        Return Temp(1, 1)
    End Function

    Sub Wait()
        Thread.Sleep(TimeSpan.FromSeconds(0.8))
    End Sub

    Sub CentreConsole(ByVal text As String)
        Dim Push As Integer
        Push = WindowWidth / 2 - Len(text) / 2
        If Push < 0 Then
            Push = Push * -1
        End If
        WriteLine(Space(Push) & text)
    End Sub

    Sub CentreConsoleWrite(ByVal text As String)
        Dim Push As Integer
        Push = WindowWidth / 2 - Len(text) / 2
        If Push < 0 Then
            Push = Push * -1
        End If
        Write(Space(Push) & text)
    End Sub

    Sub Grid(PlayerRace As String)
        Dim X As Integer = 1
        Dim Y As Integer = 1
        Dim OldX As Integer
        Dim OldY As Integer
        Dim Grid(4, 6) As String
        Dim Location As String
        Dim WyvernKilled As Boolean
        Dim CaveIlluminated As Boolean
        Dim TorchCollected As Boolean
        Dim GemCollected As Boolean
        Dim FishCollected As Boolean
        Dim WeaponCollected As Boolean
        Dim GameOver As Boolean
        Dim Temp(1, 1) As Integer

        Grid(1, 1) = "BT"
        Grid(1, 2) = "CD"
        Grid(1, 3) = "CD"
        Grid(1, 4) = "C"
        Grid(1, 5) = "C"
        Grid(1, 6) = "F"
        Grid(2, 1) = "ME"
        Grid(2, 2) = "DE"
        Grid(2, 3) = "CE"
        Grid(2, 4) = "DE"
        Grid(2, 5) = "F"
        Grid(2, 6) = "F"
        Grid(3, 1) = "T"
        Grid(3, 2) = "M"
        Grid(3, 3) = "F"
        Grid(3, 4) = "F"
        Grid(3, 5) = "FG"
        Grid(3, 6) = "W"
        Grid(4, 1) = "M"
        Grid(4, 2) = "M"
        Grid(4, 3) = "V"
        Grid(4, 4) = "W"
        Grid(4, 5) = "W"
        Grid(4, 6) = "D"

        Do
            OldX = X
            OldY = Y
            Temp(1, 1) = Navigation(X, Y)
            Temp(1, 0) = X
            Temp(0, 1) = Y
            Location = Grid(X, Y)

            Select Case Location
                Case Is = "BT"
                    Wait()
                    CentreConsole("You are back at Balthazaar's tower... without having defeated the wyvern. I don't know what exactly you are expecting... a medal?")

                Case Is = "CD"
                    Wait()
                    CentreConsole("You have crept into a pitch black cave in the mountains. You see a flicker of movement in the darkness.")
                    If CaveIlluminated <> True Then
                        Wait()
                        CentreConsole("It would be dangerous to continue into the cave in such darkness.")
                        If PlayerRace = "Elf" Or PlayerRace = "elf" Then
                            CentreConsole("So you use your elven magic to illuminate the cave, light bouncing off the walls and bats fleeing in surprise.")
                            CaveIlluminated = True
                        End If
                        If TorchCollected = True Then
                            CentreConsole("So you hold out the burning torch forwards in front of you, scaring off a few bats as you do so.")
                            CaveIlluminated = True
                        End If
                        CentreConsole("")
                    End If

                Case Is = "C"
                    Wait()
                    CentreConsole("You delve deeper into the cavern, slowly descending into the mountain.")
                    If CaveIlluminated <> True Then
                        Wait()
                        CentreConsole("You trip and fall in the darkness. The last thing you see is the cave filling with the flapping of wings as bats encircle you and hearing the excited squealing as they bare their fangs.")
                        CentreConsoleWrite("GAME")
                        Wait()
                        CentreConsole(" OVER.")
                        GameOver = True
                    Else
                        If RandomEncounter() <> 3 And RandomEncounter() <> 1 And RandomEncounter() <> 9 Then
                            GameOver = Battle(PlayerRace, Location, WeaponCollected)
                        End If
                    End If

                Case Is = "CE"
                    Wait()
                    CentreConsole("On one side you can see the arched entrance leading down into a cavern in the mountains And on the another is dense forest.")

                Case Is = "D"
                    GameOver = Battle(PlayerRace, Location, WeaponCollected)

                    If GameOver = False Then
                        WyvernKilled = True
                        If WeaponCollected = True Then
                            Wait()
                            CentreConsole("You shoot the wyvern with the elven bow, the engraved runes shining as the arrow pierces the wyvern's heart, killing it. ")
                        End If
                        Wait()
                        CentreConsole("You have defeated the wyvern, this is as far as the game goes for now.")
                    End If

                Case Is = "DE"
                    Wait()
                    CentreConsole("You have reached a dead end. You hang around for a little while, searching For a way through but eventually you give up and turn back the way you came.")
                    X = OldX
                    Y = OldY

                Case Is = "F"
                    Wait()
                    CentreConsole("You have entered the dense forest, carefully making your way through the undergrowth, cautious of creatures who may threaten you.")
                    If RandomEncounter() <> 3 And RandomEncounter() <> 1 And RandomEncounter() <> 9 Then
                        GameOver = Battle(PlayerRace, Location, WeaponCollected)
                    End If

                Case Is = "FG"
                    Wait()
                    CentreConsole("You make your way into a forest glade. A tranquil lake lies In the centre Of the glade, the only ripples caused by a few fish swimming elegantly through it.")
                    If FishCollected <> True Then
                        If PlayerRace = "Man" Or PlayerRace = "man" Then
                            Wait()
                            CentreConsole("You wade into the water And quickly Catch a fish, it's vibrant scales glinting in the sunlight. That could be useful later.")
                            FishCollected = True
                        End If
                    End If

                Case Is = "M"
                    Wait()
                    CentreConsole("You clamber through the mountains, alert for possible danger.")
                    If GemCollected <> True Then
                        If PlayerRace = "Dwarf" Or PlayerRace = "dwarf" Then
                            CentreConsole("You spot a gemstone glinting amongst the rubble of a landslide. You are quickly able to extract it from ore with your handy pickaxe.")
                            GemCollected = True
                        End If
                    End If
                    If RandomEncounter() <> 3 And RandomEncounter() <> 1 And RandomEncounter() <> 9 Then
                        GameOver = Battle(PlayerRace, Location, WeaponCollected)
                    End If

                Case Is = "ME"
                    Wait()
                    CentreConsole("You make your way up into the mountains, starting to find it harder to breathe as you climb higher and higher.")

                Case Is = "V"
                    If WeaponCollected = True Then
                        Wait()
                        CentreConsole("There is nothing of interest here.")
                    Else
                        Wait()
                        CentreConsole("You find the one village which is still standing, a frightened boy at the gates. In his hand is a elven longbow, the weapon glowing with sacred runes. He glares at you as your approach, his eyes cold as ice.")
                        Wait()
                        CentreConsole("Boy: You say you can kill the wyvern with this weapon? Your pretty words won't feed my family.")
                        If FishCollected = True Then
                            Wait()
                            CentreConsole("The starving boy takes one look at the fish which you brought out before nodding. It was a deal, you have traded and recieved the bow.")
                            WeaponCollected = True
                        End If
                        If GemCollected = True Then
                            Wait()
                            CentreConsole("The boy stares at the shining gemstone which you brought out greedily and you can tell it was a deal. You get the bow.")
                            WeaponCollected = True
                        End If
                        If WeaponCollected <> True Then
                            Wait()
                            CentreConsole("The boy will not give up his bow so easily, you will have to fight him for it.")
                            GameOver = Battle(PlayerRace, Location, WeaponCollected)
                            If GameOver = False Then
                                WeaponCollected = True
                            End If

                        End If
                    End If

                Case Is = "W"
                    Wait()
                    CentreConsole("You stumble upon the wyvern's destruction. A plain of simply cracked wasteland, emptied of all human life.")
                    If RandomEncounter() <> 3 And RandomEncounter() <> 1 And RandomEncounter() <> 9 Then
                        GameOver = Battle(PlayerRace, Location, WeaponCollected)
                    End If

                Case Is = "T"
                    If TorchCollected <> True Then
                        Wait()
                        CentreConsole("You see a burning torch on a bracket dug into the side of the mountain path. Even though it is bright as day, you quickly extract it in case it could be useful later.")
                        TorchCollected = True
                    Else
                        Wait()
                        CentreConsole("There is nothing of interest here.")
                    End If
            End Select

        Loop Until WyvernKilled = True Or GameOver = True
    End Sub

    Sub Main()
        Dim PlayerName As String
        Dim PlayerRace As String
        Dim ValidPlayerChoice As Boolean

        Title = "Text-Based Adventure Game"
        BackgroundColor = ConsoleColor.White
        ForegroundColor = ConsoleColor.Black
        CentreConsoleWrite("Greetings traveller, my name is Alfar and you are? ")
        PlayerName = ReadLine()

        Wait()
        CentreConsole("Very well, " & PlayerName & ". Welcome to Midgard, the centre of the great world tree Yggdrasil.")
        Wait()
        CentreConsole("Many creatures roam the land Of Midgard, from dwarves and elves to giants or man.")
        Wait()
        CentreConsoleWrite("Which race do you belong to again? ")
        PlayerRace = ReadLine()

        Do
            If PlayerRace = "Dwarf" Or PlayerRace = "dwarf" Or PlayerRace = "Elf" Or PlayerRace = "elf" Or PlayerRace = "Giant" Or PlayerRace = "giant" Or PlayerRace = "Man" Or PlayerRace = "man" Then
                If PlayerRace = "Elf" Or PlayerRace = "elf" Then
                    CentreConsole("Ah, my spectacles must need changing, of course you're an " & PlayerRace & ".")
                Else
                    CentreConsole("Ah, my spectacles must need changing, of course you're a " & PlayerRace & ".")
                End If
                ValidPlayerChoice = True
            Else
                CentreConsoleWrite("I must not have heard you correctly. Which race did you say you belonged to again? ")
                PlayerRace = ReadLine()
                ValidPlayerChoice = False
            End If
        Loop Until ValidPlayerChoice = True

        Select Case PlayerRace
            Case Is = "Elf", "elf"
                PlayerHealth = 40
            Case Is = "Man", "man"
                PlayerHealth = 50
            Case Is = "Giant", "giant"
                PlayerHealth = 70
            Case Is = "Dwarf", "dwarf"
                PlayerHealth = 60
        End Select


        Wait()
        CentreConsole("Enough of this chatter, I guess you'll be wanting to see the wizard? Very well, come along then.")
        Wait()
        CentreConsole("Wizard: I am Balthazaar, the great wizard.")
        Wait()
        CentreConsole("Balthazaar: Speak, " & PlayerName & ". What have you come here for?")
        Wait()
        CentreConsole("Balthazaar: You seek wisdom? Well then you must first prove yourself. There is a wyvern terrorising the north of the island, vanquish him and return here.")
        CentreConsole("")
        Wait()
        CentreConsole("You are quickly dismissed from Balthazaar's tower, wondering how exactly you are expected to kill a wyvern.")

        Grid(PlayerRace)
        ReadLine()
    End Sub

End Module
