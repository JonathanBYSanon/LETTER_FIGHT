# 🏆 Letter Clash

**Letter Clash** is a **strategic word battle game** where two players take turns choosing letters to form a hidden word. The challenge? **Every chosen letter must be used**—or face the risk of a challenge!

## 🎮 How to Play
1. **Two players** take turns selecting letters. 🆎
2. The goal is to secretly construct a **valid word** that contains **all the chosen letters**. 🔠
3. If a player can’t find a valid word, they can either:
   - Find a new word ✅
   - **Challenge** their opponent to reveal their word ⚔️
4. **Winning Challenges**:
   - If the revealed word is **valid**, the challenged player **scores points** equal to the word's length. ✅
   - If the word is **invalid** (missing letters or not real), the challenger **earns points** equal to the number of chosen letters so far. 🚫
5. **Victory**: The first player to reach the target **score wins**! 🏆

---

## 🛠️ Technologies Used
- **C# (WPF)** - Game frontend
- **MVVM Architecture** - Clean separation of UI and logic
- **.NET Framework** - Core functionality
- **HtmlAgilityPack** - Used for potential dictionary validation
- **Matrix-Themed UI** - Immersive cyber-style visuals

---

## 📂 Project Structure
```
📦 LETTER_FIGHT
 ┣ 📂 Converter/        # Data conversion utilities
 ┣ 📂 Core/             # Core game logic
 ┣ 📂 Model/            # Game-related data models
 ┣ 📂 Resources/        # Assets (images, HTML, sounds)
 ┃ ┣ 📂 HTML/
 ┃ ┣ 📂 Images/
 ┣ 📂 Service/         # Backend services (e.g., word validation, game state)
 ┣ 📂 Style/           # Game styling and themes
 ┣ 📂 View/            # UI components
 ┃ ┣ 📂 Element/       # Reusable UI components
 ┃ ┣ 📄 GameView.xaml  # The main game screen
 ┃ ┣ 📄 HelpView.xaml  # Displays rules and instructions
 ┃ ┣ 📄 MenuView.xaml  # Main menu interface
 ┃ ┣ 📄 SettingView.xaml  # Allows game customization
 ┣ 📂 ViewModel/       # MVVM ViewModel classes
 ┣ 📄 App.xaml
 ┣ 📄 MainWindow.xaml
 ┣ 📄 packages.config
```

---

## 🚀 Setup & Installation
1. **Clone the repository**:
   ```sh
   git clone https://github.com/JonathanBYSanon/LETTER_FIGHT.git
   ```
2. Open the project in **Visual Studio**.
3. Build and run the `LETTER_FIGHT` project.

---

## 🔥 Features
- **Matrix-Themed UI** 🎯
- **Strategic Word Challenges** 🔠
- **Player vs. Player Mode** 🆚
- **Scoring & Challenge System** ⚔️
- **Customizable Game Settings** ⚙️

---

## 📌 Future Plans
- **Multiplayer Mode**
- **AI Opponent**
- **Word Database & Validation Enhancements**
- **Power-Ups & Special Abilities**

---

Feel free to contribute or report any issues!
