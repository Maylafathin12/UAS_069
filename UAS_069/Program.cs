using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_069
{
    class Node // menambahkan class node
    {
        public int idbarang;
        public string namabarang;
        public Node next;
        public string jenisbarang;
        public int hargabarang;
    }
    class List //menambahkan class list
    {
        Node START;
        public List()
        {
            START = null;
        }
        public void insertdata()
        {
            int idbrg, hargabrg;
            string namabrg, jenisbrg;
            Console.WriteLine("Masukkan Id Barang:     ");
            idbrg = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukkan Harga Barang:  ");
            hargabrg = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Masukkan Nama Barang:  ");
            namabrg = Console.ReadLine();
            Console.WriteLine("Masukkan Jenis Barang:  ");
            jenisbrg = Console.ReadLine();
            Node newnode = new Node();
            newnode.idbarang = idbrg;
            newnode.hargabarang = hargabrg;
            newnode.jenisbarang = jenisbrg;
            newnode.namabarang = namabrg;

            if (START == null || idbrg <= START.idbarang)
            {
                if ((START != null) && (idbrg == START.idbarang))
                {
                    Console.WriteLine("--------");
                    return;
                }
                newnode.next = START;
                START = newnode;
                return;
            }

            Node previous, current;
            previous = START;
            current = START;

            while ((current != null) && (idbrg >= current.idbarang))
            {
                if (idbrg == current.idbarang)
                {
                    Console.WriteLine("------");
                    return;
                }
                previous = current;
                current = current.next;
            }

            newnode.next = current;
            newnode.next = previous;
        }
        public bool deletedata(int idbrg)
        {
            Node previous, current;
            previous = current = null;

            if (searchdata(idbrg, ref previous, ref current) == false)
                return false;
            previous.next = current.next;
            if (current == START)
                START = START.next;
            return true;

        }
        public bool searchdata(int idbrg, ref Node previous, ref Node current)
        {
            previous = START;
            current = START;

            while ((current != null) && (idbrg != current.idbarang))
            {
                previous = current;
                current = current.next;
            }
            if (current == null)
                return (false);
            else
                return (true);
        }
        public void displaydata()
        {
            if (ListEmpty())
                Console.WriteLine("\nToko List Empty :\n");
                else
                {

                    Console.WriteLine("\nToko Elektronik :\n");
                    Node currentNode;
                    for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                        Console.Write(currentNode.idbarang + " " + currentNode.namabarang + "\n");
                    Console.WriteLine();
                }
        }
        public bool ListEmpty()
        {
            if (START == null)
                return true;
                return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List obj = new List();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Insert data");
                    Console.WriteLine("2. Delete data");
                    Console.WriteLine("3. Display data");
                    Console.WriteLine("4. Mengurutkan data");
                    Console.WriteLine("5. Search data");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nMasukkan pilihan (1-6): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.insertdata();
                            }
                            break;
                        case '2':
                            {
                                if (obj.ListEmpty())
                                {
                                    Console.WriteLine("\nBarang tidak ada");
                                    break;
                                }
                                Console.Write("\nMasukkan Id Barang" + " Barang yang akan dihapus: ");
                                int idbarang = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.deletedata(idbarang) == false)
                                    Console.WriteLine("\nId bARANG " + idbarang + " dihapus ");
                            }
                            break;
                        case '3':
                            {
                                obj.displaydata();
                            }
                            break;
                        case '4':
                            {
                                obj.displaydata();
                            }
                            break;
                        case '5':
                            {
                                if (obj.ListEmpty() == true)
                                {

                                }
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan Salah!");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nPeriksa angka yang dimasukkan.");
                }
            }
        }
    }
}

