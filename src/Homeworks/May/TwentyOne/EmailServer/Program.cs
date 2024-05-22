namespace Server;

class Message
{
    private readonly string _senderEmail;
    private readonly string _message;

    public Message(string senderEmail, string message)
    {
        _senderEmail = senderEmail;
        _message = message;
    }

    public string GetSenderEmail()
    {
        return _senderEmail;
    }

    public string GetMessage()
    {
        return _message;
    }

    public override string ToString()
    {
        return $"From: {_senderEmail}\nMessage: {_message}";
    }
}

class EmailServer
{
    private readonly Dictionary<string, Client> _clients;

    public EmailServer()
    {
        _clients = new Dictionary<string, Client>();
    }

    public bool IsClientRegistered(Client client)
    {
        return _clients.ContainsKey(client.GetEmail());
    }

    public bool IsClientRegistered(string email)
    {
        return _clients.ContainsKey(email);
    }

    public bool RegisterClient(Client client)
    {
        if (IsClientRegistered(client))
        {
            return false;
        }

        _clients[client.GetEmail()] = client;

        return true;
    }

    public bool ResolveMessage(Message message, string email)
    {
        if (!IsClientRegistered(email))
        {
            return false;
        }

        _clients[email].GetInbox().Add(message);

        return true;
    }
}

class Client
{
    private readonly string _name;
    private readonly string _lastName;
    private readonly string _email;
    private readonly List<Message> _inbox;

    public Client(string name, string lastName, string email)
    {
        _name = name;
        _lastName = lastName;
        _email = email;
        _inbox = new List<Message>();
    }

    public string GetName()
    {
        return _name;
    }

    public string GetLastName()
    {
        return _lastName;
    }

    public string GetEmail()
    {
        return _email;
    }

    public List<Message> GetInbox()
    {
        return _inbox;
    }

    public bool SendMessage(EmailServer server, string message, string receiverEmail)
    {
        return server.ResolveMessage(new Message(_email, message), receiverEmail);
    }

    public string GetLastMessage()
    {
        if (_inbox.Count == 0)
        {
            return "No messages";
        }

        return _inbox.Last().ToString();
    }
}

class Program
{
    public static void Main(string[] args)
    {
        var server = new EmailServer();

        var client1 = new Client("Juan", "Perez", "juan.perez@gmail.com");
        var client2 = new Client("Maria", "Lopez", "maria.lopez@gmail.com");

        Console.WriteLine(server.RegisterClient(client1) == true);
        Console.WriteLine(server.RegisterClient(client2) == true);
        Console.WriteLine(server.RegisterClient(client1) == false);
        Console.WriteLine(server.RegisterClient(client2) == false);

        Console.WriteLine(
            client1.SendMessage(server, "Hello Maria", "maria.lopez@gmail.com") == true
        );
        Console.WriteLine(
            client2.SendMessage(server, "Hello Juan", "juan.perez@gmail.com") == true
        );

        Console.WriteLine(client1.GetLastMessage());
        Console.WriteLine(client2.GetLastMessage());
    }
}
