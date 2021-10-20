package Entidades;

public class Login {
    private Object userId;
    private Object senha;
    private Object token;

    public Login(Object userId, Object senha, Object token) {
        this.userId = userId;
        this.senha = senha;
        this.token = token;        
    }

    public Object getuserId()
    {
        return this.userId;
    }

    public Object getsenha()
    {
        return this.senha;
    }

    public Object gettoken()
    {
        return this.token;
    }

    public void setuserId(Object value)
    {
         this.userId = value;
    }

    public void setsenha(Object value)
    {
         this.senha = value;
    }

    public void settoken(Object value)
    {
         this.token = value;
    }
}
