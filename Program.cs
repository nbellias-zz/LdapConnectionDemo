// See https://aka.ms/new-console-template for more information


using Novell.Directory.Ldap;

const string ldapHost = "192.168.178.4";
const int ldapPort = 389;
const string domainComponent = ",dc=devlab,dc=local";

Console.WriteLine("LDAP authentication demo!");
Console.WriteLine(ldapAuthenticate("achmakiss","a.123456"));


string ldapAuthenticate(string userName, string passWord)
{
    string message = "SUCCESFULL LOGIN";

    try
    {
        var cn = new LdapConnection();

        cn.Connect(ldapHost, ldapPort);
        cn.Bind("cn=" + userName + domainComponent, passWord);

        //Console.WriteLine(cn.WhoAmI());
        //Console.WriteLine(cn.FetchSchema("cn=" + userName + ",dc=devlab,dc=local"));

        cn.Disconnect();
    }
    catch (LdapException e)
    {
        return "LDAP Error: " + e.Message;
    }
    catch (Exception e)
    {
        return "LDAP Other Error:" + e.Message;
    }

    return message;
}




