# 🎮 My Unity Platformer Project

> Un proyecto de juego de plataformas 2D desarrollado en Unity con sistema de controles, animaciones y mecánicas de daño.

---

## 📋 Resumen del Proyecto

Este es un proyecto de videojuego de plataformas 2D creado en Unity que incluye:

- **🎯 Sistema de Control del Jugador**: Movimiento fluido y responsive usando el nuevo Input System de Unity
- **💥 Sistema de Daño**: Mecánicas de combate y gestión de vida
- **🎨 Animaciones**: Sistema completo de animaciones para el personaje
- **🗺️ TileMap**: Niveles diseñados con sistema de tiles para crear mundos detallados
- **🎬 Universal Render Pipeline (URP)**: Gráficos optimizados y modernos

---

## 🔗 Cómo Conectar con GitHub Desktop

### **Paso 1: Instalar GitHub Desktop**
1. Descarga [GitHub Desktop](https://desktop.github.com/) si aún no lo tienes instalado
2. Instala y abre la aplicación
3. Inicia sesión con tu cuenta de GitHub

### **Paso 2: Clonar el Repositorio** (Si ya existe en GitHub)
1. Abre **GitHub Desktop**
2. Ve a `File` → `Clone Repository...`
3. Selecciona el repositorio de la lista o usa la URL del repositorio
4. Elige la ubicación donde quieres guardar el proyecto
5. Haz clic en **Clone**

### **Paso 3: Añadir un Proyecto Local Existente** (Si el proyecto ya está en tu PC)
1. Abre **GitHub Desktop**
2. Ve a `File` → `Add Local Repository...`
3. Haz clic en **Choose...** y navega hasta la carpeta del proyecto: `l:\Unity\My project`
4. Haz clic en **Add Repository**

### **Paso 4: Crear un Nuevo Repositorio** (Si es la primera vez)
1. Abre **GitHub Desktop**
2. Ve a `File` → `New Repository...` o `Add` → `Create New Repository...`
3. Rellena los datos:
   - **Name**: `My-Unity-Project` (o el nombre que prefieras)
   - **Local Path**: Selecciona `l:\Unity`
   - **Git Ignore**: Selecciona **Unity** de la lista
4. Haz clic en **Create Repository**

### **Paso 5: Publicar en GitHub** (Opcional)
1. En GitHub Desktop, haz clic en **Publish Repository**
2. Elige si quieres que sea público o privado
3. Haz clic en **Publish Repository**

### **📝 Hacer Commits y Push**
1. Realiza cambios en tu proyecto Unity
2. Abre **GitHub Desktop** - verás los archivos modificados en la pestaña **Changes**
3. Escribe un mensaje descriptivo en **Summary** (ej: "Añadido sistema de salto")
4. Haz clic en **Commit to main**
5. Haz clic en **Push origin** para subir los cambios a GitHub

---

## 🎯 Cómo Usar el Proyecto en Unity

### **Requisitos Previos**
- **Unity Hub** instalado ([Descargar aquí](https://unity.com/download))
- **Unity Editor** (versión recomendada: la que se usó para crear el proyecto)
- **Git** instalado en tu sistema

### **Paso 1: Abrir Unity Hub**
1. Abre **Unity Hub**
2. Si no tienes la versión correcta de Unity instalada, ve a `Installs` y descarga la versión necesaria

### **Paso 2: Añadir el Proyecto**
1. En Unity Hub, ve a la pestaña **Projects**
2. Haz clic en **Add** (o **Open**)
3. Navega hasta la carpeta del proyecto: `l:\Unity\My project`
4. Selecciona la carpeta y haz clic en **Select Folder** (o **Abrir**)

### **Paso 3: Abrir el Proyecto**
1. El proyecto aparecerá en tu lista de proyectos
2. Haz clic en el nombre del proyecto para abrirlo
3. Unity cargará el proyecto (puede tardar unos minutos la primera vez)

### **Paso 4: Explorar el Proyecto**
Una vez abierto, encontrarás:

- **📁 Scenes**: Abre `Assets/Scenes` para ver y editar los niveles
- **📜 Scripts**: Los scripts de control están en `Assets/Scripts`
  - `PlayerController.cs` - Control del jugador
  - `DamageController.cs` - Sistema de daño
- **🎨 Animations**: Animaciones del personaje en `Assets/Animations`
- **🗺️ TileMap**: Recursos de tiles en `Assets/TileMap`

### **Paso 5: Ejecutar el Juego**
1. Abre una escena desde `Assets/Scenes`
2. Haz clic en el botón **Play** ▶️ en la parte superior
3. Prueba el juego en la ventana Game
4. Haz clic en **Play** nuevamente para detener

---

## 📂 Estructura del Proyecto

```
My project/
├── Assets/
│   ├── Animations/          # Animaciones del personaje
│   ├── Assets Imports/      # Assets importados
│   ├── Prefabs/             # Prefabs reutilizables
│   ├── Scenes/              # Escenas del juego
│   ├── Scripts/             # Scripts C#
│   │   ├── PlayerController.cs
│   │   └── DamageController.cs
│   ├── Settings/            # Configuraciones del proyecto
│   └── TileMap/             # Tiles y mapas
├── ProjectSettings/         # Configuración de Unity
├── Packages/                # Paquetes de Unity
└── .gitignore              # Archivos ignorados por Git
```

---

## 🛠️ Tecnologías Utilizadas

- **Unity 2022.x+** - Motor de juego
- **C#** - Lenguaje de programación
- **Universal Render Pipeline (URP)** - Pipeline de renderizado
- **Unity Input System** - Sistema moderno de inputs
- **Tilemap System** - Sistema de mapas con tiles

---

## 💡 Consejos y Buenas Prácticas

### **Para Git/GitHub:**
- ✅ Haz commits frecuentes con mensajes descriptivos
- ✅ Usa `.gitignore` para Unity (ya incluido)
- ✅ No subas las carpetas `Library/`, `Temp/`, `Logs/` (ya están ignoradas)
- ✅ Sincroniza regularmente con `Pull` antes de hacer cambios

### **Para Unity:**
- ✅ Guarda tus escenas frecuentemente (`Ctrl + S`)
- ✅ Organiza tus assets en carpetas lógicas
- ✅ Usa prefabs para objetos reutilizables
- ✅ Prueba el juego regularmente con el botón Play

---

## 🚀 Próximos Pasos

1. **Explora el código** en `Assets/Scripts/`
2. **Modifica las escenas** en `Assets/Scenes/`
3. **Añade nuevas mecánicas** creando nuevos scripts
4. **Diseña niveles** usando el sistema de TileMap
5. **Haz commits** de tus cambios regularmente

---

## ❓ Preguntas Frecuentes (FAQ)

### **¿Necesito instalar Cinemachine u otros paquetes manualmente en otro PC?**
**¡No!** El repositorio ya incluye toda la información necesaria. Cuando clones el proyecto y lo abras en Unity:

1. Unity lee el archivo `Packages/manifest.json` (que SÍ está en el repositorio)
2. Descarga automáticamente todos los paquetes necesarios:
   - ✅ **Cinemachine** (v3.1.5)
   - ✅ **Input System** (v1.14.2)
   - ✅ **Universal Render Pipeline** (v17.0.4)
   - ✅ Y todos los demás paquetes del proyecto
3. Los instala automáticamente en tu PC

**No necesitas hacer nada**, Unity se encarga de todo. Solo asegúrate de tener conexión a internet la primera vez que abras el proyecto.

### **¿Qué archivos se suben a GitHub?**
- ✅ **Assets/** - Todos tus scripts, escenas, prefabs, etc.
- ✅ **ProjectSettings/** - Configuración del proyecto
- ✅ **Packages/manifest.json** - Lista de paquetes (incluye Cinemachine)
- ✅ **Packages/packages-lock.json** - Versiones exactas de paquetes

### **¿Qué NO se sube a GitHub?**
- ❌ **Library/** - Cache de Unity (se regenera automáticamente)
- ❌ **Temp/** - Archivos temporales
- ❌ **Logs/** - Registros de Unity
- ❌ **obj/** - Archivos de compilación

Estos archivos están en el `.gitignore` porque son muy pesados y se generan automáticamente.

---

## 📞 Soporte

Si tienes problemas:
- Revisa la [documentación de Unity](https://docs.unity3d.com/)
- Consulta la [guía de GitHub Desktop](https://docs.github.com/es/desktop)
- Verifica que todas las dependencias estén instaladas

---

<div align="center">

**¡Feliz desarrollo! 🎮✨**

Hecho con ❤️ en Unity

</div>
