# Ejercicio 3 - Tarea 1: Generador de pacientes infinito

## Descripción
Este programa simula un generador de pacientes que crea pacientes de manera continua, cada 2 segundos, con datos aleatorios:
- **Tiempo de consulta:** Entre 5 y 15 segundos.
- **Prioridad:** Emergencia (1), Urgencia (2) o Consulta general (3).
- **Requiere diagnóstico:** 50% de probabilidad.

El sistema gestiona la atención de los pacientes utilizando 4 consultas médicas y 2 máquinas de diagnóstico, como en los ejercicios anteriores.

## Requisitos
- **.NET SDK 9.0 o superior:** Para compilar y ejecutar el programa.
- **Git:** Para clonar el repositorio y gestionar versiones.

## Estructura del código

### Clase `Paciente`
La clase `Paciente` representa a un paciente con los siguientes atributos:
- **Id:** Identificador único del paciente.
- **LlegadaHospital:** Tiempo de llegada al hospital.
- **TiempoConsulta:** Tiempo de consulta con el médico.
- **RequiereDiagnostico:** Indica si el paciente necesita diagnóstico adicional.
- **Prioridad:** Nivel de prioridad del paciente (1: Emergencia, 2: Urgencia, 3: Consulta general).
- **Estado:** Estado actual del paciente (EsperaConsulta, Consulta, EsperaDiagnostico, Diagnostico, Finalizado).
- **TiempoEspera:** Tiempo que el paciente ha esperado antes de ser atendido.
- **TiempoTotalEnHospital:** Tiempo total que el paciente ha estado en el hospital.

### Método `AtenderAsync`
Este método simula la atención del paciente, incluyendo la consulta médica y el diagnóstico (si es necesario). Utiliza semáforos (`SemaphoreSlim`) para controlar el acceso a las consultas médicas y las máquinas de diagnóstico.

### Generador de pacientes
El programa genera pacientes de manera continua, cada 2 segundos, con datos aleatorios. Los pacientes son atendidos en función de su prioridad y se muestran estadísticas en tiempo real.

## Ejecución del programa

Ejemplo de salida
Al ejecutar el programa, verás una salida similar a la siguiente:
Paciente 1. Llegado el 0. Prioridad: 1. Estado: Consulta. Duración Espera: 0 segundos.
Paciente 1. Llegado el 0. Prioridad: 1. Estado: Finalizado. Tiempo total en el hospital: 10 segundos.
Paciente 2. Llegado el 2. Prioridad: 2. Estado: Consulta. Duración Espera: 0 segundos.
Paciente 2. Llegado el 2. Prioridad: 2. Estado: Finalizado. Tiempo total en el hospital: 12 segundos.


## Preguntas y respuestas
- **1.** ¿El generador de pacientes cumple con los requisitos?
Sí, el generador de pacientes cumple con los requisitos al crear pacientes de manera continua, cada 2 segundos, con datos aleatorios.

- **2.** ¿Qué comportamientos no previstos detectas?
Al aumentar el número de pacientes (N = 50, 100, 1000), se pueden observar los siguientes comportamientos no previstos:

Saturación de recursos: Si hay muchos pacientes que requieren diagnóstico, las máquinas de diagnóstico pueden saturarse, aumentando el tiempo de espera.

Colas largas: Los pacientes pueden acumularse en la cola de espera, especialmente si hay muchos pacientes con alta prioridad.

- **3.** ¿Cómo adaptarías tu solución ante este nuevo escenario?
Para manejar un mayor número de pacientes, se podrían implementar las siguientes mejoras:

Aumentar el número de consultas médicas y máquinas de diagnóstico.

Implementar un sistema de prioridades más eficiente para reducir el tiempo de espera de los pacientes con mayor urgencia.

Limitar el número máximo de pacientes en el sistema para evitar la saturación de recursos.

## Capturas de pantalla
A continuación se muestra una captura de pantalla de la ejecución del programa:
![image](https://github.com/user-attachments/assets/5036939d-11ab-4c0a-b207-a5c6ea3a435e)



## Conclusión
Este programa simula un generador de pacientes infinito, donde los pacientes son atendidos en función de su prioridad y se muestran estadísticas en tiempo real. Se ha utilizado sincronización para garantizar que los recursos no se sobresaturen y que los pacientes sean atendidos en el orden correcto.

