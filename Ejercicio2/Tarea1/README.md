# Ejercicio 2 - Tarea 1: Unidades de diagnóstico

## Descripción
Este programa amplía la simulación del hospital para incluir unidades de diagnóstico. Los pacientes pueden requerir pruebas de diagnóstico adicionales, y el hospital tiene 2 máquinas de diagnóstico disponibles.

## Requisitos
- Cada paciente tiene un identificador único, tiempo de llegada, tiempo de consulta y puede requerir diagnóstico.
- Los pacientes llegan cada 2 segundos.
- Cada médico atiende a un paciente durante un tiempo aleatorio entre 5 y 15 segundos.
- Si un paciente requiere diagnóstico, usa una de las 2 máquinas disponibles durante 15 segundos.

## Ejecución del programa
Al ejecutar el programa, se mostrarán mensajes como:

Paciente 42. Llegado el 1. Estado: Consulta. Duración Espera: 2 segundos.

Paciente 42. Llegado el 1. Estado: EsperaDiagnostico.

Paciente 42. Llegado el 1. Estado: Diagnostico.

Paciente 42. Llegado el 1. Estado: Finalizado.

Todos los pacientes han sido atendidos.
