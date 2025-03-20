# Ejercicio 2 - Tarea 5: Estadísticas y logs

## Descripción
Este programa amplía la simulación del hospital para mostrar estadísticas al final de la simulación, incluyendo:
1. **Número total de pacientes atendidos por prioridad.**
2. **Tiempo promedio de espera por paciente.**
3. **Uso promedio de las máquinas de diagnóstico.**

## Requisitos
- Mostrar estadísticas detalladas al final de la simulación.
- Calcular el tiempo promedio de espera por paciente.
- Calcular el uso promedio de las máquinas de diagnóstico.

## Implementación

### Estadísticas finales
Al finalizar la simulación, se muestran las siguientes estadísticas:
- **Pacientes atendidos por prioridad:** Número de pacientes atendidos en cada nivel de prioridad.
- **Tiempo promedio de espera:** Tiempo promedio que los pacientes esperaron antes de ser atendidos.
- **Uso promedio de las máquinas de diagnóstico:** Número promedio de pacientes que usaron cada máquina de diagnóstico.

### Ejemplo de salida
--- ESTADÍSTICAS FINALES ---
Pacientes con prioridad 1: 5
Tiempo promedio de espera: 10.50 segundos
Pacientes con prioridad 2: 8
Tiempo promedio de espera: 15.25 segundos
Pacientes con prioridad 3: 7
Tiempo promedio de espera: 20.00 segundos

Uso promedio de las máquinas de diagnóstico: 7.50 pacientes por máquina


## Preguntas y respuestas

### 1. ¿Cómo se calcula el tiempo promedio de espera?
El tiempo promedio de espera se calcula sumando el tiempo de espera de todos los pacientes en un grupo de prioridad y dividiéndolo entre el número de pacientes en ese grupo.

### 2. ¿Cómo se calcula el uso promedio de las máquinas de diagnóstico?
El uso promedio de las máquinas de diagnóstico se calcula dividiendo el número total de pacientes que requirieron diagnóstico entre el número de máquinas disponibles (2).

### 3. ¿Qué otra información podría ser útil mostrar?
Otra información útil podría ser:
- **Tiempo total en el hospital:** Desde que el paciente llega hasta que finaliza la consulta y el diagnóstico (si es necesario).
- **Médico asignado:** Para saber qué médico atendió a cada paciente.
- **Tiempo de uso de las máquinas de diagnóstico:** Para ver cuánto tiempo estuvieron en uso las máquinas.

## Conclusión
Este programa simula la atención de pacientes en un hospital con un sistema de prioridades y muestra estadísticas detalladas al final de la simulación. Se ha utilizado sincronización para garantizar que los recursos no se sobresaturen y que los pacientes sean atendidos en el orden correcto.
