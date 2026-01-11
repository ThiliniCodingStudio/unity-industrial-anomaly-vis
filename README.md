# 3D Industrial Anomaly Visualization (Unity Prototype)

A **UX Engineering prototype** exploring interaction patterns for "Digital Twin" industrial dashboards. This project demonstrates how **3D Exploded Views** and **State-Based Visuals** can reduce cognitive load for reliability engineers monitoring complex machinery.

## 🧠 UX Logic & Interaction Design
The core objective was to translate raw sensor data into immediate, pre-attentive visual cues.

### 1. The State Machine (Visual Feedback)
To communicate urgency without relying on text, I implemented a generic **State Machine** (`AnomalyStateManager.cs`) that maps data severity to visual attributes:
* **Normal State:** Neutral color, static mesh.
* **Warning State:** Orange highlight, slow breathing animation (0.5Hz).
* **Critical State:** Red alert, rapid flash (2.0Hz) to trigger immediate operator attention.

### 2. Interactive Inspection (Exploded View)
Complex internal failures are often obscured by the machine's casing. The Exploded View feature spreads outward all model parts according to a defined axis to visualize internal components.

![3D Exploded View Demonstration](docs/exploded-view-demo.png)<img width="821" height="367" alt="Screenshot 2026-01-11 at 14 39 11" src="https://github.com/user-attachments/assets/4c938137-1a98-4925-97f9-4aa826347d03" />

*Figure 1: Visualization of the Exploded View interacting with the Anomaly State.*

* **Interaction:** Direct manipulation (Click-to-Expand).
* **Behavior:** A linear interpolation (`Lerp`) smoothly separates components along their local vectors. By default, the explosion's center is located at the origin, but the script allows for custom pivot points to control the scatter direction.

### 3. Data Simulation
* The `MockDataStream.cs` script simulates a JSON payload from an anomaly detection backend, proving the system's ability to react to live `severity` flags dynamically.

## 🛠 Tech Stack
* **Engine:** Unity 2022 (LTS)
* **Language:** C# (Focus on Interaction Logic & Coroutines)
* **Pattern:** Component-Based State Management

---
*Developed as a proof-of-concept for Industrial HMI interactions.*
