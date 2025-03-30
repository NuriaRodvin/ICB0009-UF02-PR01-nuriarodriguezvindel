# 🏥 Práctica ICB0009-UF2-PR01 - Simulación de Atención Hospitalaria

## 📋 Descripción de la práctica
Esta práctica simula la gestión de la atención hospitalaria en un entorno controlado. El hospital cuenta con:
- **4 consultas médicas** atendidas por médicos.
- **2 máquinas de diagnóstico** para pruebas adicionales.
- **Pacientes** que llegan al hospital con diferentes niveles de prioridad (emergencia, urgencia, consulta general) y pueden requerir diagnóstico.

La práctica está dividida en **3 ejercicios**, cada uno con varias tareas que abordan diferentes aspectos de la simulación.

---

## 🧪 Ejercicios y tareas

### 📌 Ejercicio 1: Atención médica básica
En este ejercicio se simula la llegada de pacientes al hospital y su atención en las consultas médicas.

#### 🛠️ Tareas:
1. **Tarea 1:** Simular la llegada de 4 pacientes y su atención en 4 consultas médicas.
2. **Tarea 2:** Ampliar la simulación para que los pacientes tengan datos específicos (ID, tiempo de llegada, tiempo de consulta, estado).
3. **Tarea 3:** Mostrar el avance de los pacientes en tiempo real, incluyendo su estado y tiempo de espera.

#### ❓ Preguntas y respuestas:
1. **¿Cuántos hilos se están ejecutando en este programa?**
   - Se ejecutan **5 hilos en total**: 1 hilo principal (Main) y 4 hilos adicionales (uno por cada paciente).

2. **¿Cuál de los pacientes entra primero en consulta?**
   - El **paciente 1** entra primero en consulta porque es el primero en llegar.

3. **¿Cuál de los pacientes sale primero de consulta?**
   - Cualquiera de los pacientes puede salir primero, ya que la asignación de médicos es aleatoria.

---

### 📌 Ejercicio 2: Unidades de diagnóstico y prioridades
En este ejercicio se amplía la simulación para incluir máquinas de diagnóstico y un sistema de prioridades para los pacientes.

#### 🛠️ Tareas:
1. **Tarea 1:** Ampliar la clase `Paciente` para incluir la necesidad de diagnóstico y gestionar el uso de las máquinas de diagnóstico.
2. **Tarea 2:** Sincronizar las pruebas de diagnóstico para que los pacientes las realicen en el orden de llegada.
3. **Tarea 3:** Simular la llegada de 20 pacientes y gestionar su atención con prioridades.
4. **Tarea 4:** Implementar un sistema de prioridades para los pacientes (emergencia, urgencia, consulta general).
5. **Tarea 5:** Mostrar estadísticas finales, como el número de pacientes atendidos por prioridad, el tiempo promedio de espera y el uso de las máquinas de diagnóstico.

#### ❓ Preguntas y respuestas:
1. **¿Los pacientes que deben esperar para hacerse las pruebas diagnóstico entran luego a hacerse las pruebas por orden de llegada?**
   - Sí, los pacientes realizan las pruebas de diagnóstico en el orden de llegada, utilizando una cola (`Queue`) para mantener el orden.

2. **¿Qué otra información podría ser útil visualizar?**
   - Otra información útil podría ser el **tiempo total en el hospital**, el **médico asignado** y el **tiempo de uso de las máquinas de diagnóstico**.

---

### 📌 Ejercicio 3: Generador de pacientes infinito
En este ejercicio se simula un generador de pacientes que crea pacientes de manera continua, cada 2 segundos, con datos aleatorios.

#### 🛠️ Tareas:
1. **Tarea 1:** Crear un generador de pacientes infinito que genere pacientes con datos aleatorios (tiempo de consulta, prioridad, necesidad de diagnóstico).
2. **Pruebas:** Probar el sistema con diferentes cantidades de pacientes (N = 50, 100, 1000) y analizar el comportamiento.

#### ❓ Preguntas y respuestas:
1. **¿El generador de pacientes cumple con los requisitos?**
   - Sí, el generador de pacientes cumple con los requisitos al crear pacientes de manera continua, cada 2 segundos, con datos aleatorios.

2. **¿Qué comportamientos no previstos detectas?**
   - Al aumentar el número de pacientes, se pueden observar **colas largas** y **saturación de recursos**, especialmente en las máquinas de diagnóstico.

3. **¿Cómo adaptarías tu solución ante este nuevo escenario?**
   - Se podrían implementar mejoras como **aumentar el número de consultas médicas y máquinas de diagnóstico**, o **limitar el número máximo de pacientes en el sistema**.

---

## 📂 Estructura del repositorio

El repositorio está organizado en carpetas para cada ejercicio y tarea:

ICB0009-UF2-PR01-nuriarodriguezvindel/
├── Ejercicio1/
│ ├── Tarea1/
│ ├── Tarea2/
│ └── Tarea3/
├── Ejercicio2/
│ ├── Tarea1/
│ ├── Tarea2/
│ ├── Tarea3/
│ ├── Tarea4/
│ └── Tarea5/
└── Ejercicio3/
└── Tarea1/



Cada carpeta contiene:
- **Código fuente:** Archivos `.cs` con la implementación de la simulación.
- **README.md:** Documentación específica de la tarea, incluyendo preguntas y respuestas.

---

## 🚀 Ejecución del código

### 📋 Requisitos
- **.NET SDK 9.0 o superior:** Para compilar y ejecutar el código.
- **Git:** Para clonar el repositorio y gestionar versiones.

### 🛠️ Pasos para ejecutar el código
1. **Clona el repositorio:**

    ```bash
   git clone https://github.com/NuriaRodvin/ICB0009-UF02-PR01-nuriarodriguezvindel.git


Navega a la carpeta de la tarea que deseas ejecutar:

cd ICB0009-UF02-PR01-nuriarodriguezvindel/EjercicioX/TareaY

Compila y ejecuta el programa:

dotnet run


🏁 Conclusión
Esta práctica ha permitido simular la gestión de la atención hospitalaria, desde la llegada de pacientes hasta su atención en consultas médicas y pruebas de diagnóstico. Se ha utilizado programación asíncrona y sincronización para garantizar que los recursos no se sobresaturen y que los pacientes sean atendidos en el orden correcto.

🔗 Enlace al repositorio
Puedes acceder al repositorio completo en GitHub:
ICB0009-UF02-PR01-nuriarodriguezvindel










