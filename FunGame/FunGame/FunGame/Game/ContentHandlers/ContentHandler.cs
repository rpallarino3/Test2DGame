using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace FunGame.Game.ContentHandlers
{
    class ContentHandler
    {

        private ContentManager content;

        private PlayerContentHandler playerContentHandler;
        private ObjectContentHandler objectContentHandler;
        private AbilityContentHandler abilityContentHandler;
        private CharacterContentHandler characterContentHandler;
        private MenuAndUIContentHandler menuUIContentHandler;
        private NPCContentHandler npcContentHandler;
        private ZoneContentHandler zoneContentHandler;
        private ChatContentHandler chatContentHandler;

        public ContentHandler(ContentManager content)
        {
            this.content = content;
            playerContentHandler = new PlayerContentHandler(content);
            objectContentHandler = new ObjectContentHandler(content);
            abilityContentHandler = new AbilityContentHandler(content);
            characterContentHandler = new CharacterContentHandler(content);
            menuUIContentHandler = new MenuAndUIContentHandler(content);
            npcContentHandler = new NPCContentHandler(content);
            zoneContentHandler = new ZoneContentHandler(content);
            chatContentHandler = new ChatContentHandler(content);
        }

        public void loadContent()
        {
            loadPlayerContent();
            loadObjectContent();
            loadZoneContent();
            loadNPCContent();
            loadAbilityContent();
            loadCharacterContent();
            loadUIContent();
            loadChatContent();
        }

        private void loadPlayerContent()
        {
            playerContentHandler.loadContent();
        }

        private void loadObjectContent()
        {
            objectContentHandler.loadContent();
        }

        private void loadAbilityContent()
        {
            abilityContentHandler.loadContent();
        }

        private void loadCharacterContent()
        {
            characterContentHandler.loadContent();
        }

        private void loadUIContent()
        {
            menuUIContentHandler.loadContent();
        }

        private void loadZoneContent()
        {
            zoneContentHandler.loadContent();
        }

        private void loadNPCContent()
        {
            npcContentHandler.loadContent();
        }

        private void loadChatContent()
        {
            chatContentHandler.loadContent();
        }

        public AbilityContentHandler getAbilityContentHandler()
        {
            return abilityContentHandler;
        }

        public PlayerContentHandler getPlayerContentHandler()
        {
            return playerContentHandler;
        }

        public ObjectContentHandler getObjectContentHandler()
        {
            return objectContentHandler;
        }

        public CharacterContentHandler getCharacterContentHandler()
        {
            return characterContentHandler;
        }

        public MenuAndUIContentHandler getMenuUIContentHandler()
        {
            return menuUIContentHandler;
        }

        public NPCContentHandler getNPCContentHandler()
        {
            return npcContentHandler;
        }

        public ZoneContentHandler getZoneContentHandler()
        {
            return zoneContentHandler;
        }

        public ChatContentHandler getChatContentHandler()
        {
            return chatContentHandler;
        }
    }
}
