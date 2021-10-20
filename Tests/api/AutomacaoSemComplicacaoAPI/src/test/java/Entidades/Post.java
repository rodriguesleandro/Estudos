package Entidades;

public class Post {
    
            private Object userId;
            private Object id;
            private Object title;
            private Object body;

            public Post(Object userId, Object id, Object title, Object body)
             {
                this.userId = userId;
            this.id = id;
            this.title = title;
            this.body = body;
             }

            public Object getuserId()
            {
                return this.userId;
            }
            public void setuserId(Object value)
            {
                this.userId = value;
            }
            

            public Object getid()
            {
                return this.id;
            }
            public void setid(Object value)
            {
                this.id = value;
            }

            public Object gettitle()
            {
                return this.title;
            }
            public void settitle(Object value)
            {
                this.title = value;
            }

            public Object getbody()
            {
                return this.body;
            }
            public void setbody(Object value)
            {
                this.body = value;
            }


            
}
