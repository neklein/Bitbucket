using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RPG.Inventory.Items.Containers;
using RPG.Inventory.Items.Potions;
using RPG.Inventory.Items;
using RPG.Inventory.Items.Weapons;
using RPG.Inventory.Items.Containers.Restrictions;


namespace RPG.Inventory.Tests
{
    [TestFixture]
    public class ContainerTests
    {
        [Test]
        public void CanAddItemToBackpack()
        {
            Backpack b = new Backpack();
            HealthPotion p = new HealthPotion();

            AddItemStatus actual = b.AddItem(p);
            Assert.AreEqual(AddItemStatus.Ok, actual);
        }

        [Test]
        public void CannotAddItemToFullBackpack()
        {
            Backpack b = new Backpack();
            GreatAxe axe = new GreatAxe();

            b.AddItem(axe);
            b.AddItem(axe);
            b.AddItem(axe);
            b.AddItem(axe);

            AddItemStatus actual = b.AddItem(axe);
            Assert.AreEqual(AddItemStatus.ContainerFull, actual);
        }

        [Test]
        public void CanRemoveItemFromBackpack()
        {
            Backpack b = new Backpack();
            HealthPotion p = new HealthPotion();

            b.AddItem(p);

            Item actual = b.RemoveItem();

            // do these two variables reference the same object
            Assert.AreEqual(p, actual);
        }

        [Test]
        public void EmptyBagReturnsNull()
        {
            Backpack b = new Backpack();
            Item item = b.RemoveItem();

            Assert.IsNull(item);
        }

        [Test]
        public void PotionSatchelOnlyAllowsPotions()
        {
            PotionSatchel satchel = new PotionSatchel();
            GreatAxe axe = new GreatAxe();

            AddItemStatus result = satchel.AddItem(axe);
            Assert.AreEqual(AddItemStatus.ItemWrongType, result);

            HealthPotion potion = new HealthPotion();
            result = satchel.AddItem(potion);
            Assert.AreEqual(AddItemStatus.Ok, result);
        }

        
            [Test]
            public void PotionSatchelRequiresPotions()
            {
            PotionSatchel p = new PotionSatchel();

            HealthPotion potion = new HealthPotion();
            GreatAxe ga = new GreatAxe();

            Assert.AreEqual(AddItemStatus.Ok, p.AddItem(potion));
            Assert.AreEqual(AddItemStatus.ItemWrongType, p.AddItem(ga));
            }

        [Test]
        public void ItemTypeRestrictionWorks()
        {
            ItemTypeRestriction restriction = new ItemTypeRestriction(ItemType.Weapon);

            AddItemStatus result = restriction.AddItem(new HealthPotion(), null);

            Assert.AreEqual(AddItemStatus.ItemWrongType, result);
        }
        
        [Test]
        public void MaxWeightRestriction()
        {
            WetPaperSack bag = new WetPaperSack();

            AddItemStatus actual = bag.AddItem(new GreatAxe());

            Assert.AreEqual(AddItemStatus.ContainerOverWeight, actual);
        }

        [Test]
        public void ShapeRestriction()
        {
            WeaponContainer container = new WeaponContainer();

            GreatAxe axe = new GreatAxe();
            AddItemStatus actual = container.AddItem(axe);

            Assert.AreEqual(AddItemStatus.ItemWrongShape, actual);

            Sword sword = new Sword();
            AddItemStatus actual1 = container.AddItem(sword);

            Assert.AreEqual(AddItemStatus.Ok, actual1);

        }
    }
}
