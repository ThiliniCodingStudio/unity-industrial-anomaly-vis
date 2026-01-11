3D Industrial Anomaly Visualization (Unity Prototype)

A **UX Engineering prototype** exploring interaction patterns for "Digital Twin" industrial dashboards. This project demonstrates how **3D Exploded Views** and **State-Based Visuals** can reduce cognitive load for reliability engineers monitoring complex machinery.

## 🧠 UX Logic & Interaction Design
The core objective was to translate raw sensor data into immediate, pre-attentive visual cues.

### 1. The State Machine (Visual Feedback)
To communicate urgency without relying on text, I implemented a generic **State Machine** (`AnomalyStateManager.cs`) that maps data severity to visual attributes:
* **Normal State:** Neutral color, static mesh.
* **Warning State:** Orange highlight, slow breathing animation (0.5Hz).
* **Critical State:** Red alert, rapid flash (2.0Hz) to trigger immediate operator attention.

### 2. Interactive Inspection (Exploded View)
Complex internal failures are often obscured by the machine's casing.
* **Interaction:** Direct manipulation (Click-to-Expand).
* **Behavior:** A linear interpolation (`Lerp`) smoothly separates components along their local vectors, allowing the user to inspect internal heatmaps without losing context of the assembly structure.

### 3. Data Simulation
* The `MockDataStream.cs` script simulates a JSON payload from an anomaly detection backend, proving the system's ability to react to live `severity` flags dynamically.

## 🛠 Tech Stack
* **Engine:** Unity 2022 (LTS)
* **Language:** C# (Focus on Interaction Logic & Coroutines)
* **Pattern:** Component-Based State Management
