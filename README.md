Se implementa MVC, agregando los controladores necesarios para su invocación, interfaces con los metodos necesarios a implementar, así como los modelos de las clases con las propiedades necesarias.

En el front tambien se utiliza el patron MVC agregando Interfaces, Servicios, y Vistas en el proceso de registro de pagos.

Se utiliza la inyección de dependencias para poder disponer del contexto de la conexión a la base de datos, utilizando singleton para sólo instanciarse una vez, y poder utilizarlo en cualquier clase que lo requiera.
