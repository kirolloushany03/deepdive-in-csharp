using MultiProject.ClassLibarary;

kiroPublicClass.SayQuote();

KiroPublicClassWithInternalMethod kiroin = new();

kiroin.PublicMethod();
kiroin.InternalMethod();

KiroInternaClass interclass = new();
interclass.InternalMethod();
interclass.PublicMethod();
