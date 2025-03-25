# Ejercicio 2 - Tarea 1: Unidades de Diagnóstico

## Descripción
Este programa amplía la simulación del hospital para incluir unidades de diagnóstico. Los pacientes pueden requerir pruebas adicionales, y el hospital dispone de dos máquinas de diagnóstico. Los pacientes pasan por diferentes estados: espera de consulta, consulta, espera de diagnóstico (si es necesario) y finalizado.

## Requisitos
- Cada paciente tiene un identificador único, tiempo de llegada, tiempo de consulta y puede requerir diagnóstico.
- Los pacientes llegan cada 2 segundos.
- Cada médico atiende a un paciente durante un tiempo aleatorio entre 5 y 15 segundos.
- Si un paciente requiere diagnóstico, usa una de las dos máquinas disponibles durante 15 segundos.
- Se muestra por consola el estado de los pacientes, sus cambios de estado y el tiempo entre cambios.

## Implementación

### Clase `Paciente`
Se ha ampliado la clase `Paciente` con los siguientes atributos y métodos:

- **Atributos:**
  - `Id`: Identificador único.
  - `LlegadaHospital`: Tiempo de llegada al hospital.
  - `TiempoConsulta`: Duración de la consulta.
  - `RequiereDiagnostico`: Indica si necesita diagnóstico.
  - `Estado`: Estado actual (EsperaConsulta, Consulta, EsperaDiagnostico, Diagnostico, Finalizado).
  - `TiempoEspera`: Tiempo que el paciente ha esperado antes de ser atendido.

- **Métodos:**
  - `AtenderAsync`: Simula la atención del paciente, incluyendo la consulta y el diagnóstico si es necesario.

### Sincronización de las Máquinas de Diagnóstico
Se ha utilizado un `SemaphoreSlim` para controlar el acceso a las dos máquinas de diagnóstico, garantizando que solo dos pacientes puedan usarlas simultáneamente.

### Visualización
Se muestra por consola el estado de cada paciente, junto con su tiempo de espera y duración de la consulta o diagnóstico. Ejemplo:

```
Paciente 42. Llegado el 1. Estado: Consulta. Duración Espera: 2 segundos.
Paciente 42. Llegado el 1. Estado: EsperaDiagnostico.
Paciente 42. Llegado el 1. Estado: Diagnostico.
Paciente 42. Llegado el 1. Estado: Finalizado.
```

## Preguntas Frecuentes

### ¿Los pacientes que requieren diagnóstico entran por orden de llegada?
No necesariamente. Los pacientes ingresan a las máquinas en el orden en que están disponibles. Como el tiempo de consulta es aleatorio, el orden de llegada no siempre se mantiene.

### ¿Qué pruebas se han realizado para comprobar este comportamiento?
Se han realizado diversas pruebas:
1. **Prueba con 4 pacientes:** Dos requieren diagnóstico y dos no. Se observa que los que requieren diagnóstico esperan hasta que una máquina esté disponible.
2. **Prueba con mayor cantidad de pacientes:** Se verifica que las máquinas de diagnóstico no excedan su límite de uso simultáneo.
3. **Prueba con tiempos de consulta variables:** Se confirma que el orden de atención en las máquinas depende de la disponibilidad y no del orden de llegada.

## Información Adicional

### ¿Se ha añadido información extra a la visualización?
Sí, se ha agregado el **tiempo de espera** de cada paciente antes de ser atendido para analizar la eficiencia del sistema.

### ¿Qué otra información podría ser útil?
- **Prioridad del paciente:** Emergencia, urgencia o consulta general.
- **Tiempo total en el hospital:** Desde la llegada hasta la finalización.
- **Médico asignado:** Para identificar quién ha atendido a cada paciente.
- **Uso de las máquinas de diagnóstico:** Para evaluar la carga de trabajo.

## Conclusión
Este programa simula la atención de pacientes en un hospital con un sistema de prioridades, donde los pacientes son atendidos en función de su nivel de urgencia. Se ha utilizado sincronización para garantizar que los recursos no se sobresaturen y que los pacientes sean atendidos en el orden correcto.

## Capturas de Pantalla

A continuación se muestra una captura de pantalla de la ejecución del programa:
![image](https://github.com/user-attachments/assets/5eb1dcce-bf3c-4775-99d1-6a68dac0efcb)

![Captura de pantalla](https://github.com/user-attachments/assets/3070b4ab-a749-4e15-87fd-9e1d1ef2b71f)



