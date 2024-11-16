Este proyecto llamado Cronometro está realizado en .NET con C# y WPF.
Los requerimientos funcionales eran que tuviera tres botones, uno para iniciarlo, otro para pausarlo
y por último para detenerlo.
Los requerimiento de diseño y código consistieron en utilizar MVVM y principios SOLID:
1 - Responsabilidad Única: La interfaz ICronometro no incluye lógica de implementación, sólo define las funcionalidades del Cronómetro.
La responsabilidad exclusiva de realizar la lógica del cronómetro está en CronometroModel.
2 - Abierto/Cerrado: Se pueden agregar más funcionalidades al cronómetro creando otras implementaciones de ICronometro sin modificar 
la clase Cronometro.
3 - Sustitución de Liskov: Cualquier clase que implemente ICronometro puede ser usada en lugar de usar Cronometro.
4 - Segregación de Interfaces: ICronometro define la funcionalidad necesaria para un cronómetro, La clase CronometroModel no necesita 
crear nuevas funcionalidades que tengan que ver con su funcionalidad.
5 - Inversión de Dependencias: La clase CronometroModel implementa ICronometro, y otras clases podrían utilizarla también sin importar 
cómo esté implementado el cronómetro. 




