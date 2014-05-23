using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FunGame.Game.NPCStuff;
using FunGame.Game.Environment.ManipulatableObjects;
using FunGame.Game.Environment.ZoneTiles;

using Microsoft.Xna.Framework;


namespace FunGame.Game.Environment.TestEnvironment
{
    class TestTileZone : Zone
    {

        public TestTileZone(int tileWidth, int tileHeight)
        {
            zoneNumber = -4;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            width = tileWidth * TILE_SIZE;
            height = tileHeight * TILE_SIZE;
            setDrawLocation(new Vector2(0, 0));
            zoneTileMap = new ZoneTileMap(tileHeight, tileWidth, 2);

            createLists();
            fillMap();
            addNPCS();
        }

        private void createLists()
        {
            transitionZones = new List<Zone>();
            transitionPoints = new List<Vector2>();
            npcList = new List<NPC>();
            objectList = new List<ManipulatableObject>();
        }

        private void addNPCS()
        {
            NPC testNpc = new NPC("TEST", this, new Vector2(3, 6), 1, new Vector2(30, 30), new Vector2(30, 50), 0);

            ChatPage page1 = new ChatPage();
            ChatPage page2 = new ChatPage();
            ChatPage page3 = new ChatPage();

            page1.setText(@"This is the test long string that will be parsed into small strings and individually drawn based on the text speed and such. " +
                "These next couple sentences are to test having a string that is longer than 9 lines. Blah blah blah blah poop poop poop fart fart fart fart fart I don't" +
                " if this is long enough. Guess not I will add a couple more things to make it longer. Still not long enough here are a couple more useless words");

            page1.addDestination("Yes", page2);
            page1.addDestination("No", page2);
            page1.addDestination("Test 2 line option that should be really long and take up at least 2 lines?", page2);
            page1.addDestination("Exit", page3);

            page2.setText(@"Test page 2");
            page2.addDestination("Exit", page3);
            testNpc.setExitPage(page3);
            testNpc.addChatPage(page1);
            testNpc.addChatPage(page2);
            testNpc.addChatPage(page3);

            testNpc.setFirstChatPage(page1);
            testNpc.setCurrentChatPage(page1);

            npcList.Add(testNpc);
            FreeTile ft = (FreeTile) zoneTileMap.getTile(6, 3, 1);
            ft.insertNPC();
        }

        private void fillMap()
        {
            zoneTileMap.fillImpassableRectangle(0, 0, 30, 10, 0);
            zoneTileMap.fillImpassableRectangle(0, 20, 11, 10, 0);
            zoneTileMap.fillImpassableRectangle(25, 25, 5, 5, 0);
            zoneTileMap.fillEdgeRectangle(11, 20, 9, 1, 0, 0, 0, 10);
            zoneTileMap.fillEdgeRectangle(11, 29, 9, 1, 0, 0, 20, 10);

            zoneTileMap.getTile(13, 20, 0).setPixelRectangle(29, 10, 1, 20, 2);
            zoneTileMap.getTile(13, 21, 0).setPixelRectangle(29, 0, 1, 30, 2);
            zoneTileMap.getTile(13, 22, 0).setPixelRectangle(29, 0, 1, 30, 2);
            zoneTileMap.getTile(13, 23, 0).setPixelRectangle(29, 0, 1, 30, 2);
            zoneTileMap.getTile(13, 24, 0).setPixelRectangle(29, 0, 1, 30, 2);
            zoneTileMap.getTile(13, 25, 0).setPixelRectangle(29, 0, 1, 30, 2);
            zoneTileMap.getTile(13, 26, 0).setPixelRectangle(29, 0, 1, 30, 2);
            zoneTileMap.getTile(13, 27, 0).setPixelRectangle(29, 0, 1, 30, 2);
            zoneTileMap.getTile(13, 28, 0).setPixelRectangle(29, 0, 1, 30, 2);
            zoneTileMap.getTile(13, 29, 0).setPixelRectangle(29, 0, 1, 20, 2);

            zoneTileMap.fillGapRectangle(0, 10, 3, 10, 1);
            zoneTileMap.fillGapRectangle(6, 10, 24, 10, 1);
            zoneTileMap.fillGapRectangle(20, 20, 10, 10, 1);
            zoneTileMap.fillEdgeRectangle(6, 20, 14, 1, 1, 0, 0, 10);
            zoneTileMap.fillEdgeRectangle(1, 29, 19, 1, 1, 0, 20, 10);
            zoneTileMap.fillCornerRectangle(0, 29, 1, 1, 1, 1, 20, 20);
            zoneTileMap.fillEdgeRectangle(0, 21, 1, 8, 1, 1, 0, 10);
            zoneTileMap.fillCornerRectangle(0, 20, 1, 1, 1, 0, 20, 20);
            zoneTileMap.fillEdgeRectangle(1, 20, 2, 1, 1, 0, 0, 10);
            zoneTileMap.fillRectangularCornerRectangle(3, 20, 1, 1, 1, 0, 10, 10);
            zoneTileMap.fillEdgeRectangle(3, 10, 1, 10, 1, 1, 0, 10);
            zoneTileMap.fillRectangularCornerRectangle(3, 9, 1, 1, 1, 1, 20, 10);
            zoneTileMap.fillEdgeRectangle(1, 9, 2, 1, 1, 0, 20, 10);
            zoneTileMap.fillCornerRectangle(0, 9, 1, 1, 1, 1, 20, 20);
            zoneTileMap.fillEdgeRectangle(0, 1, 1, 8, 1, 1, 0, 10);
            zoneTileMap.fillCornerRectangle(0, 0, 1, 1, 1, 0, 20, 20);
            zoneTileMap.fillEdgeRectangle(1, 0, 28, 1, 1, 0, 0, 10);
            zoneTileMap.fillCornerRectangle(29, 0, 1, 1, 1, 3, 20, 20);
            zoneTileMap.fillEdgeRectangle(29, 1, 1, 8, 1, 1, 20, 10);
            zoneTileMap.fillCornerRectangle(29, 9, 1, 1, 1, 2, 20, 20);
            zoneTileMap.fillEdgeRectangle(28, 9, 1, 1, 1, 0, 20, 10);
            zoneTileMap.fillEdgeRectangle(6, 9, 21, 1, 1, 0, 20, 10);
            zoneTileMap.fillRectangularCornerRectangle(5, 9, 1, 1, 1, 2, 20, 20);
            zoneTileMap.fillEdgeRectangle(5, 10, 1, 10, 1, 1, 20, 10);
            zoneTileMap.fillRectangularCornerRectangle(5, 20, 1, 1, 1, 3, 10, 20);

            zoneTileMap.fillEdgeRectangle(26, 25, 1, 1, 1, 0, 0, 10);
            zoneTileMap.fillCornerRectangle(25, 25, 1, 1, 1, 0, 20, 20);
            zoneTileMap.fillEdgeRectangle(25, 26, 1, 3, 1, 1, 0, 10);
            zoneTileMap.fillCornerRectangle(25, 29, 1, 1, 1, 1, 20, 20);
            zoneTileMap.fillEdgeRectangle(26, 29, 3, 1, 1, 0, 20, 10);
            zoneTileMap.fillCornerRectangle(29, 29, 1, 1, 1, 2, 20, 20);
            zoneTileMap.fillEdgeRectangle(29, 26, 1, 3, 1, 1, 20, 10);
            zoneTileMap.fillCornerRectangle(29, 25, 1, 1, 1, 3, 20, 20);
            zoneTileMap.fillEdgeRectangle(28, 25, 1, 1, 1, 0, 0, 10);

            zoneTileMap.getTile(18, 20, 1).setPixelRectangle(29, 10, 1, 20, 3);
            zoneTileMap.getTile(18, 21, 1).setPixelRectangle(29, 0, 1, 30, 3);
            zoneTileMap.getTile(18, 22, 1).setPixelRectangle(29, 0, 1, 30, 3);
            zoneTileMap.getTile(18, 23, 1).setPixelRectangle(29, 0, 1, 30, 3);
            zoneTileMap.getTile(18, 24, 1).setPixelRectangle(29, 0, 1, 30, 3);
            zoneTileMap.getTile(18, 25, 1).setPixelRectangle(29, 0, 1, 30, 3);
            zoneTileMap.getTile(18, 26, 1).setPixelRectangle(29, 0, 1, 30, 3);
            zoneTileMap.getTile(18, 27, 1).setPixelRectangle(29, 0, 1, 30, 3);
            zoneTileMap.getTile(18, 28, 1).setPixelRectangle(29, 0, 1, 30, 3);
            zoneTileMap.getTile(18, 29, 1).setPixelRectangle(29, 0, 1, 20, 3);

            SteppingStone stone1 = new SteppingStone(28, 11, 0);
            SteppingStone stone2 = new SteppingStone(28, 13, 0);
            SteppingStone stone3 = new SteppingStone(27, 15, 0);
            SteppingStone stone4 = new SteppingStone(28, 17, 0);
            SteppingStone stone5 = new SteppingStone(28, 19, 0);
            zoneTileMap.fillTileWithObject(28, 11, 0, stone1);
            zoneTileMap.fillTileWithObject(28, 13, 0, stone2);
            zoneTileMap.fillTileWithObject(27, 15, 0, stone3);
            zoneTileMap.fillTileWithObject(28, 17, 0, stone4);
            zoneTileMap.fillTileWithObject(28, 19, 0, stone5);
            zoneTileMap.insertObject(27, 11, 1, stone1);
            zoneTileMap.insertObject(27, 13, 1, stone2);
            zoneTileMap.insertObject(26, 15, 1, stone3);
            zoneTileMap.insertObject(27, 17, 1, stone4);
            zoneTileMap.insertObject(27, 19, 1, stone5);
            objectList.Add(stone1);
            objectList.Add(stone2);
            objectList.Add(stone3);
            objectList.Add(stone4);
            objectList.Add(stone5);

            TallGrass grass1 = new TallGrass(20, 20, 0);
            TallGrass grass2 = new TallGrass(20, 21, 0);
            TallGrass grass3 = new TallGrass(20, 22, 0);
            TallGrass grass4 = new TallGrass(20, 23, 0);
            TallGrass grass5 = new TallGrass(20, 24, 0);
            TallGrass grass6 = new TallGrass(21, 20, 0);
            TallGrass grass7 = new TallGrass(21, 21, 0);
            TallGrass grass8 = new TallGrass(21, 22, 0);
            TallGrass grass9 = new TallGrass(21, 23, 0);
            TallGrass grass10 = new TallGrass(21, 24, 0);
            zoneTileMap.insertObject(20, 20, 0, grass1);
            zoneTileMap.insertObject(20, 21, 0, grass2);
            zoneTileMap.insertObject(20, 22, 0, grass3);
            zoneTileMap.insertObject(20, 23, 0, grass4);
            zoneTileMap.insertObject(20, 24, 0, grass5);
            zoneTileMap.insertObject(21, 20, 0, grass6);
            zoneTileMap.insertObject(21, 21, 0, grass7);
            zoneTileMap.insertObject(21, 22, 0, grass8);
            zoneTileMap.insertObject(21, 23, 0, grass9);
            zoneTileMap.insertObject(21, 24, 0, grass10);
            objectList.Add(grass1);
            objectList.Add(grass2);
            objectList.Add(grass3);
            objectList.Add(grass4);
            objectList.Add(grass5);
            objectList.Add(grass6);
            objectList.Add(grass7);
            objectList.Add(grass8);
            objectList.Add(grass9);
            objectList.Add(grass10);

            TallGrass grass11 = new TallGrass(22, 20, 0);
            zoneTileMap.insertObject(22, 20, 0, grass11);
            objectList.Add(grass11);

            grass11 = new TallGrass(22, 21, 0);
            zoneTileMap.insertObject(22, 21, 0, grass11);
            objectList.Add(grass11);
            grass11 = new TallGrass(22, 22, 0);
            zoneTileMap.insertObject(22, 22, 0, grass11);
            objectList.Add(grass11);
            grass11 = new TallGrass(22, 23, 0);
            zoneTileMap.insertObject(22, 23, 0, grass11);
            objectList.Add(grass11);
            grass11 = new TallGrass(22, 24, 0);
            zoneTileMap.insertObject(22, 24, 0, grass11);
            objectList.Add(grass11);
            grass11 = new TallGrass(22, 25, 0);
            zoneTileMap.insertObject(22, 25, 0, grass11);
            objectList.Add(grass11);
            grass11 = new TallGrass(22, 26, 0);
            zoneTileMap.insertObject(22, 26, 0, grass11);
            objectList.Add(grass11);
            grass11 = new TallGrass(22, 27, 0);
            zoneTileMap.insertObject(22, 27, 0, grass11);
            objectList.Add(grass11);
            grass11 = new TallGrass(22, 28, 0);
            zoneTileMap.insertObject(22, 28, 0, grass11);
            objectList.Add(grass11);
            grass11 = new TallGrass(22, 29, 0);
            zoneTileMap.insertObject(22, 29, 0, grass11);
            objectList.Add(grass11);
        }
    }
}
