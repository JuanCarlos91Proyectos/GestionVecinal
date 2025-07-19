* Seguir buenas prácticas .NET 8
* Asegurarse de evitar warnings que puedan afectar a sonar
* El naming de las clases, interfaces, métodos, propiedades, etc. debe ser en inglés
* Utilizar lowerCamelCase para los nombres de las propiedades
* Utilizar UpperCamelCase para los nombres de las clases, interfaces, métodos, etc.
* Los comentarios en el código deben ser en inglés
* Comentar todos los métodos y propiedades públicas con XML comments
* Utilizar siempre el formato de interpolación de cadenas para las cadenas que contienen variables
* Seguir las convenciones de nomenclatura de C# para los nombres de los archivos y carpetas
* Seguir buenas prácticas de arquitectura de software y patrones de diseño
* Seguir principios KISS (Keep It Simple, Stupid) y YAGNI (You Aren't Gonna Need It), SOLID, DRY (Don't Repeat Yourself)

## Proyecto

* El proyecto es .Net 8 basado en Clean Architecture por capas

  * Proyecto principal
  * Models
  * Repositories
  * Services
  * ViewModels
  * Models
  * WinUI

* Siempre respetar la responsabilidad de cada capa para seguir la arquitectura, utilizar DI e interfaces para poder testar las funcionalidades

## Test

* Los test están hechos con XUnit y Moq
* Existe un proyecto de test llamado UnitTest en el cual especificamos los test unitarios

  * Para los test especificar siempre el namespace en función del directorio en el que está el test, como por ejemplo "namespace UnitTest.Application.Configuration;"
