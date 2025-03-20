# Ejercicio 1 - Tarea 3: Visualización del avance

## Descripción
Este programa muestra información detallada sobre el estado de los pacientes, incluyendo su tiempo de llegada, estado actual y duración de la consulta. Los pacientes llegan cada 2 segundos y son atendidos por médicos en un tiempo de consulta variable.

## Requisitos
- Mostrar el ID del paciente, su orden de llegada, estado y duración de la consulta.
- Los pacientes llegan cada 2 segundos.
- Cada médico atiende a un paciente durante un tiempo aleatorio entre 5 y 15 segundos.

## Preguntas

### ¿Has decidido visualizar información adicional a la planteada en el ejercicio? ¿Por qué?
Sí, he decidido mostrar el **tiempo de espera** de cada paciente antes de ser atendido. Esto es útil para entender cuánto tiempo pasan los pacientes en la sala de espera antes de ser atendidos.

## Ejecución del programa
Al ejecutar el programa, se mostrarán mensajes como:

Paciente 71. Llegado el 1. Estado: Consulta. Duración Espera: 0 segundos.

Paciente 24. Llegado el 2. Estado: Consulta. Duración Espera: 0 segundos.

Paciente 5. Llegado el 3. Estado: Consulta. Duración Espera: 0 segundos.

Paciente 71. Llegado el 1. Estado: Finalizado. Duración Consulta: 5 segundos.

Paciente 92. Llegado el 4. Estado: Consulta. Duración Espera: 0 segundos.

Paciente 5. Llegado el 3. Estado: Finalizado. Duración Consulta: 8 segundos.

Paciente 24. Llegado el 2. Estado: Finalizado. Duración Consulta: 12 segundos.

Paciente 92. Llegado el 4. Estado: Finalizado. Duración Consulta: 13 segundos.

Todos los pacientes han sido atendidos.


## Capturas de pantalla
![image](https://github.com/user-attachments/assets/a26f30e7-b027-4e57-938a-09b393f13f1f)

## Preguntas

### ¿Has decidido visualizar información adicional a la planteada en el ejercicio? ¿Por qué?
Sí, he decidido mostrar el **tiempo de espera** de cada paciente antes de ser atendido. Esto es útil para entender cuánto tiempo pasan los pacientes en la sala de espera antes de ser atendidos.

### ¿Qué otra información podría ser útil visualizar?
Otra información útil podría ser:
- **Prioridad del paciente:** Para saber si es una emergencia, urgencia o consulta general.
- **Tiempo total en el hospital:** Desde que el paciente llega hasta que finaliza la consulta.
- **Médico asignado:** Para saber qué médico atendió a cada paciente.


