# 🤖 POE-Wrapper

1) Téléchargez MPos portable https://freefr.dl.sourceforge.net/project/mpos/v.0.5/MPos-v.0.5.0-Portable.zip
2) Identifiez les bonnes coordonnées pour :
   - la textbox en bas de la page du bot
   - le centre de la page
   - le contextmenu (clique droit) qui permet de copier le message
3) Modifiez les coordonnées dans le code source

## Usage 

```bash
poe.exe "le prompt à envoyer au bot" "l'url complète du bot" "le nom du fichier où sauvegarder la réponse"
```

Exemple : 

```bash
poe.exe "La paix est-elle le plus grand des biens ?" "https://poe.com/Pl-aiton" "rep_00000001.txt"
```

# ✅ TODO
- [ ] Faire en sorte de pouvoir gérer plusieurs comptes
   - [ ] solutions 1 (700 messages max) : faire un compte par navigateur (on a le droit à 100 messages par jour et par compte, 3000 points et c'est 30 points par msg Claude-instant)
      - [ ] installer opéra
      - [ ] installer chrome
      - [ ] installer firefox
      - [ ] installer brave
      - [ ] installer arc
      - [ ] installer vivaldi
      - [ ] installer maxthon
   - [ ] solutions 2 (∞ messages) : faire plusieurs comptes Quora/Poe et faire plusieurs instances d'un même navigateur
      - [ ] gérer les profils Chrome 
