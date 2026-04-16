# 🎭 Sistema de Venta de Entradas de Teatro

## 📌 Descripción

Aplicación de consola desarrollada en C# que simula la venta de entradas para un teatro. El sistema permite visualizar el estado de las butacas, realizar ventas por sector y consultar la recaudación total.

## 🚀 Funcionalidades principales

* Visualización de butacas disponibles y vendidas
* Venta de entradas por sector:

  * Preferenciales
  * Platea baja
  * Platea alta
* Selección de fila y columna para la compra
* Cálculo automático de recaudación
* Generación aleatoria del estado inicial de las butacas
* Menú interactivo en consola

## 🛠 Tecnologías utilizadas

* C#
* .NET
* Aplicación de consola
* Visual Studio

## 📂 Estructura del proyecto

* `Promocion.sln` → archivo de solución
* `Program.cs` → lógica principal del sistema
* Matriz bidimensional para representar las butacas

## 🎯 Lógica del sistema

El sistema utiliza una matriz de 6 filas por 10 columnas para representar las butacas del teatro.
Cada posición puede estar:

* `0` → Disponible
* `1` → Vendida

Las butacas se dividen en sectores:

* Fila 5 → Preferenciales ($10.000)
* Filas 3 y 4 → Platea baja ($6.000)
* Filas 0, 1 y 2 → Platea alta ($3.000)

## ▶️ Cómo ejecutar el proyecto

1. Clonar o descargar el repositorio
2. Abrir `Promocion.sln` en Visual Studio
3. Ejecutar el programa con **F5**

## 📊 Extras

* Interfaz en consola con formato visual (tablas)
* Validaciones de entrada del usuario
* Control de disponibilidad de butacas

## 👨‍🎓 Autor

Pablo Alejandro
