# Ejercicio 2 - Tarea 1: Unidades de diagnóstico

## Descripción
Este programa amplía la simulación del hospital para incluir unidades de diagnóstico. Los pacientes pueden requerir pruebas de diagnóstico adicionales, y el hospital tiene 2 máquinas de diagnóstico disponibles. Los pacientes pasan por diferentes estados: espera de consulta, consulta, espera de diagnóstico (si es necesario) y finalizado.

## Requisitos
- Cada paciente tiene un identificador único, tiempo de llegada, tiempo de consulta y puede requerir diagnóstico.
- Los pacientes llegan cada 2 segundos.
- Cada médico atiende a un paciente durante un tiempo aleatorio entre 5 y 15 segundos.
- Si un paciente requiere diagnóstico, usa una de las 2 máquinas disponibles durante 15 segundos.
- Mostrar por consola el estado de los pacientes, junto con sus cambios de estado y el tiempo entre cambios.

## Implementación

### Ampliación de la clase `Paciente`
Se ha ampliado la clase `Paciente` con los siguientes atributos y métodos:
- **Atributos:**
  - `Id`: Identificador único del paciente.
  - `LlegadaHospital`: Tiempo de llegada al hospital.
  - `TiempoConsulta`: Tiempo de consulta con el médico.
  - `RequiereDiagnostico`: Indica si el paciente necesita diagnóstico adicional.
  - `Estado`: Estado actual del paciente (EsperaConsulta, Consulta, EsperaDiagnostico, Diagnostico, Finalizado).
  - `TiempoEspera`: Tiempo que el paciente ha esperado antes de ser atendido.

- **Métodos:**
  - `AtenderAsync`: Simula la atención del paciente, incluyendo la consulta y el diagnóstico (si es necesario).

### Sincronización de las máquinas de diagnóstico
Se ha utilizado un `SemaphoreSlim` para controlar el acceso a las 2 máquinas de diagnóstico. Esto garantiza que solo 2 pacientes puedan usar las máquinas simultáneamente.

### Visualización del avance
Se muestra por consola el estado de cada paciente, junto con su tiempo de espera y duración de la consulta o diagnóstico. El formato de visualización es:

Paciente <Id>. Llegado el <N>. Estado: <estado>. Duración: <S> segundos.



## Ejecución del programa
Al ejecutar el programa, se mostrarán mensajes como:

Paciente 42. Llegado el 1. Estado: Consulta. Duración Espera: 2 segundos.

Paciente 42. Llegado el 1. Estado: EsperaDiagnostico.

Paciente 42. Llegado el 1. Estado: Diagnostico.

Paciente 42. Llegado el 1. Estado: Finalizado.

Todos los pacientes han sido atendidos.


## Preguntas

### ¿Los pacientes que deben esperar para hacerse las pruebas diagnóstico entran luego a hacerse las pruebas por orden de llegada?

## Preguntas

### ¿Los pacientes que deben esperar para hacerse las pruebas diagnóstico entran luego a hacerse las pruebas por orden de llegada?
No necesariamente. Los pacientes que requieren diagnóstico entran a las máquinas en el orden en que están disponibles. Sin embargo, debido a la naturaleza aleatoria del tiempo de consulta, el orden de llegada no siempre se mantiene.

### ¿Qué tipo de pruebas has realizado para comprobar este comportamiento?
Para comprobar este comportamiento, se han realizado las siguientes pruebas:
1. **Prueba con 4 pacientes:** Dos pacientes requieren diagnóstico y dos no. Se observa que los pacientes que requieren diagnóstico esperan a que una máquina esté disponible.
2. **Prueba con más pacientes:** Se ha aumentado el número de pacientes para verificar que las máquinas de diagnóstico se asignan correctamente y que no se excede el límite de 2 máquinas simultáneas.
3. **Prueba con tiempos de consulta variables:** Se ha verificado que, independientemente del tiempo de consulta, los pacientes que requieren diagnóstico esperan su turno para usar las máquinas.

## Capturas de pantalla
A continuación se muestra una captura de pantalla de la ejecución del programa:

![Captura de pantalla](image.png)

## Respuestas adicionales

### ¿Has decidido visualizar información adicional a la planteada en el ejercicio? ¿Por qué?
Sí, he decidido mostrar el **tiempo de espera** de cada paciente antes de ser atendido. Esto es útil para entender cuánto tiempo pasan los pacientes en la sala de espera antes de ser atendidos.

### ¿Qué otra información podría ser útil visualizar?
Otra información útil podría ser:
- **Prioridad del paciente:** Para saber si es una emergencia, urgencia o consulta general.
- **Tiempo total en el hospital:** Desde que el paciente llega hasta que finaliza la consulta y el diagnóstico (si es necesario).
- **Médico asignado:** Para saber qué médico atendió a cada paciente.
- **Uso de las máquinas de diagnóstico:** Para ver cuánto tiempo están en uso las máquinas y cuántos pacientes las han utilizado.

## Conclusión
Este programa simula de manera efectiva la atención de pacientes en un hospital, incluyendo consultas médicas y pruebas de diagnóstico. Se ha utilizado sincronización para garantizar que las máquinas de diagnóstico no se sobresaturen y se ha proporcionado información detallada sobre el estado de los pacientes.

## Captura de pantalla con la ejecución:
![image](https://github.com/user-attachments/assets/3070b4ab-a749-4e15-87fd-9e1d1ef2b71f)

