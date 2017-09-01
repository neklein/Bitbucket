using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RPGInventory.Items.Containers;
using RPGInventory.Items.Potions;
using RPGInventory.Items;
using RPGInventory.Items.Weapons;

namespace RPG_Inventory.Tests
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void CanAddItemtoBackpack()
        {
            Backpack b = new Backpack();
            HealthPotion p = new HealthPotion();

            AddItemStatus actual = b.AddItem(p);
            Assert.AreEqual(AddItemStatus.Success, actual);
        }

        [Test]
        public void CannotAddItemToFullBackpack()
        {
            Backpack b = new Backpack();
            Sword sword = new Sword();

            b.AddItem(sword);
            b.AddItem(sword);
            b.AddItem(sword);
            b.AddItem(sword);

            AddItemStatus actual = b.AddItem(sword);
            Assert.AreEqual(AddItemStatus.BagIsFull, actual);
            
        }

        [Test]
        public void EmptyBagReturnsNull()
        {
            Backpack b = new Backpack();
            ItemBase actual = b.RemoveItem();

            Assert.AreEqual(null, actual);
        }

        [Test]
        public void CanRemoveItemFromBackpack()
        {
            Backpack b = new Backpack();
            HealthPotion p = new HealthPotion();

            b.AddItem(p);

            ItemBase actual = b.RemoveItem();

            //do these two variables reference the same object?
            Assert.AreEqual(p, actual);
        }

        [Test]
        public void AWeightRestrictedBagRestrictsWeight()
        {
            WetPaperSack sack = new WetPaperSack();
            HealthPotion potion = new HealthPotion();

            Assert.AreEqual(AddItemStatus.Success, sack.AddItem(potion));

            Sword sword = new Sword();
            Assert.AreEqual(AddItemStatus.ItemTooHeavy, sack.AddItem(sword));

            ItemBase item = sack.RemoveItem();
            Assert.AreEqual(AddItemStatus.Success, sack.AddItem(sword));


        }
    }
}
