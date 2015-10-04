Imports System.Console
Module Module1

    Function RandomEncounter()
        Dim RandomValue As Integer
        Randomize()
        RandomValue = CInt(Math.Floor((10 - 1 + 1) * Rnd())) + 1
        Return RandomValue
    End Function

    Function MonsterAttack(MonsterLevel As Integer)
        Dim AttackDamage As Integer
        Randomize()
        AttackDamage = CInt(Math.Floor((10 - 1 + 1) * Rnd())) + 1
        AttackDamage = AttackDamage * MonsterLevel
        Return AttackDamage
    End Function

    Function NavigationX(PlayerChoice As Char, X As Integer)
        Select Case PlayerChoice
            Case "E", "e"
                X = X + 1
                Return X
            Case "W", "w"
                X = X - 1
        End Select
        Return X
    End Function

    Function NavigationY(PlayerChoice As Char, Y As Integer)
        Select Case PlayerChoice
            Case "N", "n"
                Y = Y + 1
                Return Y
            Case "S", "s"
                Y = Y - 1
                Return Y
        End Select
        Return Y
    End Function

    Sub Main()
        Dim PlayerName As String
        Dim PlayerRace As String
        Dim ValidPlayerChoice As Boolean
        Dim WyvernKilled As Boolean
        Dim Location As String
        Dim PlayerChoice As Char
        Dim Grid(4, 6) As String
        Dim X As Integer
        Dim Y As Integer
        Y = 1
        X = 1
        Grid(1, 1) = "BT"
        Grid(1, 2) = "C"
        Grid(4, 6) = "D"


        Write("Greetings traveller my name is Alfar, and you are? ")
        PlayerName = ReadLine()

        WriteLine("Very well, " & PlayerName & ". Welcome to Midgard, the center of the great world tree Yggdrasil.")
        WriteLine("Many creatures roam the land of Midgard, from dwarves and elves to giants and men.")
        Write("Which race do you belong to again? ")
        PlayerRace = ReadLine()

        Do
            If PlayerRace = "Dwarf" Or PlayerRace = "dwarf" Or PlayerRace = "Elf" Or PlayerRace = "elf" Or PlayerRace = "Giant" Or PlayerRace = "giant" Or PlayerRace = "Man" Or PlayerRace = "man" Then
                If PlayerRace = "Elf" Or PlayerRace = "elf" Then
                    WriteLine("Ah, my spectacles must need changing, of course you're an " & PlayerRace & ".")
                Else
                    WriteLine("Ah, my spectacles must need changing, of course you're a " & PlayerRace & ".")
                End If
                ValidPlayerChoice = True
            Else
                Write("I must not have heard you correctly. Which race did you say you belonged to again? ")
                PlayerRace = ReadLine()
                ValidPlayerChoice = False
            End If
        Loop Until ValidPlayerChoice = True

        WriteLine("Enough of this chatter, I guess you'll be wanting to see the wizard? Very well, come along then.")
        WriteLine("Wizard: I am Balthazaar, the great wizard.")
        WriteLine("Balthazaar: Speak, " & PlayerName & ". What have you come here for?")
        WriteLine("Balthazaar: You seek wisdom? Well then you must first prove yourself. There is a wyvern terrorising the north of the island, vanquish him and return here.")
        WriteLine("")
        WriteLine("You are quickly dismissed from Balthazaar's tower, wondering how exactly you are expected to kill a wyvern.")
        WriteLine("You can move North or East.")
        PlayerChoice = ReadLine()

        Do
            If PlayerChoice <> "N" And PlayerChoice <> "n" And PlayerChoice <> "E" And PlayerChoice <> "e" Then
                WriteLine("Please enter either N for North or E for East.")
                PlayerChoice = ReadLine()
                ValidPlayerChoice = False
            End If
        Loop Until ValidPlayerChoice = True

        X = NavigationX(PlayerChoice, X)
        Y, X = NavigationY(PlayerChoice, Y, X)

        Do
            Location = Grid(X, Y)
            Select Case Location
                Case Is = "BT"
                    WriteLine("You are back at Balthazaar's tower... without having defeated the wyvern. I don't know what exactly you are expecting... a medal?")
                Case Is = "C"
                    WriteLine("You have entered a dark cave.")
                Case Is = "D"
                    WyvernKilled = True
            End Select
            WriteLine("Enter North, East, South or West to continue.")
            PlayerChoice = ReadLine()
            Do
                X = NavigationX(PlayerChoice, X)
                Y = NavigationY(PlayerChoice, Y)
                If X = 7 Or X = 0 Or Y = 0 Or Y = 7 Then
                    ValidPlayerChoice = False
                    WriteLine("You cannot go that way.")
                    PlayerChoice = ReadLine()
                End If
            Loop Until ValidPlayerChoice = True
        Loop Until WyvernKilled = True

        ReadLine()
    End Sub

End Module
