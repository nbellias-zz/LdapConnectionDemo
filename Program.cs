// See https://aka.ms/new-console-template for more information


using Novell.Directory.Ldap;

const string ldapHost = "myopenldap";
const int ldapPort = 389;
const string domainComponent = ",dc=mydomain,dc=home";

Console.WriteLine("LDAP authentication demo!");
Console.WriteLine(ldapAuthenticate("makrivou","evanthia00"));


string ldapAuthenticate(string userName, string passWord)
{
    string message = "SUCCESFULL LOGIN";

    try
    {
        var cn = new LdapConnection();

        cn.Connect(ldapHost, ldapPort);
        cn.Bind("cn=" + userName + domainComponent, passWord);

        //Console.WriteLine(cn.WhoAmI());
        //Console.WriteLine(cn.FetchSchema("cn=" + userName + ",dc=mydomain,dc=home"));

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




