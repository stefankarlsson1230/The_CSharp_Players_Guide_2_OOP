// This validator is realistic becasue it does'n tell you shit about why your password failed :/

PasswordValidator password;

string input;

while(true)
{
    Console.Write("Password: ");
    input = Console.ReadLine()!;

    password = new PasswordValidator(input); 
    
    if (password.Validate())
    {
        Console.WriteLine("This password is ok!");
    }
    else
    {
        Console.WriteLine("Nope! This password is not good enough!");
    }
}



// Classes
internal class PasswordValidator
{
    // Properties
    private string Password { get; set; }

    // Constructors
    public PasswordValidator(string password)
    {
        Password = password;
    }

    // Methods
    public bool Validate()
    {
        // Passwords must be at least 6 letters long and no more than 13 letters long.
        if (Password.Length < 6 || Password.Length > 13) return false;

        // Passwords must contain at least one uppercase letter, one lowercase letter, and one number.
        // Passwords cannot contain a capital T or an ampersand (&) 
        bool uppercase = false;
        bool lowercase = false;
        bool number = false;

        foreach (char c in Password)
        {
            if (c == 'T' || c == '&') return false;

            if (char.IsUpper(c)) uppercase = true;
            else if (char.IsLower(c)) lowercase = true;
            else if (char.IsNumber(c)) number = true;
        }

        return uppercase && lowercase && number;
    }
}


