# Ejercicio 2 - Tarea 2: Sincronización de pruebas de diagnóstico

## Descripción
Este programa amplía la simulación del hospital para garantizar que los pacientes realicen las pruebas de diagnóstico en el orden en que llegaron al hospital, independientemente del orden en que terminen su consulta.

## Requisitos
- Los pacientes deben realizar las pruebas de diagnóstico en el orden de llegada.
- Se utiliza una cola (`Queue`) para mantener el orden de llegada.
- Se muestra por consola el estado de los pacientes, junto con sus cambios de estado y el tiempo entre cambios.

## Implementación

### Cola de diagnóstico
Se ha utilizado una cola (`Queue`) para asegurar que los pacientes realicen las pruebas de diagnóstico en el orden en que llegaron al hospital. Los pacientes se añaden a la cola cuando terminan su consulta y esperan a ser el primero en la cola antes de usar una máquina de diagnóstico.

### Sincronización
Se ha utilizado un `SemaphoreSlim` para controlar el acceso a las 2 máquinas de diagnóstico. Esto garantiza que solo 2 pacientes puedan usar las máquinas simultáneamente.

## Ejecución del programa
Al ejecutar el programa, se mostrarán mensajes como:
Paciente 42. Llegado el 1. Estado: Consulta. Duración Espera: 2 segundos.
Paciente 42. Llegado el 1. Estado: EsperaDiagnostico.
Paciente 42. Llegado el 1. Estado: Diagnostico.
Paciente 42. Llegado el 1. Estado: Finalizado.
Todos los pacientes han sido atendidos.


## Preguntas

### Explica la solución planteada en tu código y por qué la has escogido.
La solución utiliza una cola (`Queue`) para mantener el orden de llegada de los pacientes. Cuando un paciente termina su consulta y requiere diagnóstico, se añade a la cola. El paciente solo puede usar una máquina de diagnóstico cuando es el primero en la cola. Esto garantiza que los pacientes realicen las pruebas en el orden correcto.

### Plantea otra posibilidad de solución a la que has programado.
Otra posibilidad sería usar un sistema de tickets, donde cada paciente recibe un número de ticket al llegar al hospital. Los pacientes realizarían las pruebas de diagnóstico en función de su número de ticket. Sin embargo, esta solución sería más compleja de implementar y menos eficiente que usar una cola.

## Capturas de pantalla
Incluye aquí capturas de pantalla de la ejecución del programa.

## Conclusión
Este programa garantiza que los pacientes realicen las pruebas de diagnóstico en el orden de llegada, utilizando una cola para mantener el orden y un semáforo para controlar el acceso a las máquinas de diagnóstico.