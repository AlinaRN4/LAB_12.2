using ClassLibrary10lab;
using System.Drawing;
using Лабораторная_работа_12;
using Лабораторная_работа_12._2;
namespace MyHashTableTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddPoint()
        {
            // Arrange
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();

            // Act
            MusicalInstrument instrument = new MusicalInstrument();
            hashTable.AddPoint(instrument);

            // Assert
            Assert.IsTrue(hashTable.ContainsKey(instrument));
        }

        [TestMethod]
        public void AddPoint_AddsToChain_WhenIndexIsNotEmpty()
        {
            // Arrange
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();
            MusicalInstrument musicalForAdd = new MusicalInstrument();

            musicalForAdd.RandomInit();
            hashTable.AddPoint(musicalForAdd);

            // Assert
            Assert.IsTrue(hashTable.Contains(musicalForAdd));
        }
        
        [TestMethod]
        public void RemoveByKey()
        {
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();
            MusicalInstrument instrument = new MusicalInstrument();
            hashTable.AddPoint(instrument);

            bool removed = hashTable.RemoveByKey(instrument);

            Assert.IsTrue(removed);
            Assert.IsFalse(hashTable.ContainsKey(instrument));
        }
        [TestMethod]
        public void RemoveByKey_ElementFoundInFame_ReturnsTrue()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>();
            MusicalInstrument instrument1 = new MusicalInstrument { Name = "Guitar" };
            MusicalInstrument instrument2 = new MusicalInstrument { Name = "Piano" };
            MusicalInstrument instrument3 = new MusicalInstrument { Name = "Drums" };

            table.AddPoint(instrument1);
            table.AddPoint(instrument2);
            table.AddPoint(instrument3);

            bool result = table.RemoveByKey(instrument2);

            Assert.IsTrue(result);
        }
        [TestMethod]
        public void RemoveByKey_ElementFoundAtEnd_ReturnsTrue()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>();
            MusicalInstrument instrument1 = new MusicalInstrument { Name = "Guitar" };
            MusicalInstrument instrument2 = new MusicalInstrument { Name = "Piano" };
            MusicalInstrument instrument3 = new MusicalInstrument { Name = "Drums" };

            table.AddPoint(instrument1);
            table.AddPoint(instrument2);
            table.AddPoint(instrument3);

            bool result = table.RemoveByKey(instrument3);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void RemoveByKey_ElementNotFound_ReturnsFalse()
        {
            MyHashTable<MusicalInstrument> table = new MyHashTable<MusicalInstrument>();
            MusicalInstrument instrument1 = new MusicalInstrument { Name = "Guitar" };
            MusicalInstrument instrument2 = new MusicalInstrument { Name = "Piano" };
            MusicalInstrument instrument3 = new MusicalInstrument { Name = "Drums" };

            table.AddPoint(instrument1);
            table.AddPoint(instrument2);

            bool result = table.RemoveByKey(instrument3);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void ContainsKey()
        {
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();
            MusicalInstrument instrument = new MusicalInstrument();
            hashTable.AddPoint(instrument);

            bool contains = hashTable.ContainsKey(instrument);

            Assert.IsTrue(contains);
        }

        [TestMethod]
        public void Contains_ReturnsTrue_WhenDataIsInChain()
        {
            // Arrange
            var hashTable = new MyHashTable<MusicalInstrument>();
            MusicalInstrument musicalForAdd = new MusicalInstrument();
            musicalForAdd.RandomInit();
            hashTable.AddPoint(musicalForAdd);

            // Act
            bool result = hashTable.Contains(musicalForAdd);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Contains_ReturnsFalse_WhenDataIsNotInChain()
        {
            // Arrange
            var hashTable = new MyHashTable<MusicalInstrument>();
            MusicalInstrument musicalForAdd = new MusicalInstrument();
            musicalForAdd.RandomInit();
            hashTable.AddPoint(musicalForAdd);

            MusicalInstrument musicalNotInChain = new MusicalInstrument();
            musicalNotInChain.RandomInit();

            // Act
            bool result = hashTable.Contains(musicalNotInChain);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void Contains_ReturnsTrue()
        {
            // Arrange
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();
            MusicalInstrument musicalForAdd = new MusicalInstrument();

            musicalForAdd.RandomInit();
            hashTable.AddPoint(musicalForAdd);

            // Act
            bool result = hashTable.Contains(musicalForAdd);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Contains_ReturnsFalse()
        {
            // Arrange
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();
            MusicalInstrument musicalForAdd = new MusicalInstrument();

            musicalForAdd.RandomInit();
            hashTable.AddPoint(musicalForAdd);

            MusicalInstrument musicalNotInChain = new MusicalInstrument();
            musicalNotInChain.RandomInit();

            // Act
            bool result = hashTable.Contains(musicalNotInChain);

            // Assert
            Assert.IsFalse(result);
        }
        
        [TestMethod]
        public void CreateRandomTable_AddsSpecifiedNumberOfElements()
        {
            // Arrange
            MyHashTable<MusicalInstrument> hashTable = new MyHashTable<MusicalInstrument>();
            int numberOfElements = 5;

            // Act
            hashTable.CreateRandomTable(numberOfElements);

            // Assert
            Assert.AreEqual(10, hashTable.Capacity);
        }
        [TestMethod]
        public void RemoveByKey_RemovesElementFromTable()
        {
            // Arrange
            var hashTable = new MyHashTable<MusicalInstrument>();
            hashTable.CreateRandomTable(5);

            MusicalInstrument keyToRemove = new MusicalInstrument();
            keyToRemove.RandomInit();
            // Act
            bool result = hashTable.RemoveByKey(keyToRemove);

            // Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Contains_WhenTableIsNull_ThrowException()
        {
            // Arrange
            var hashTable = new MyHashTable<MusicalInstrument>();
            MusicalInstrument key = new MusicalInstrument();
            key.RandomInit();
            // Act & Assert
            Assert.ThrowsException<Exception>(() => hashTable.Contains(key));
        }
    }
}