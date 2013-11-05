using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScratchPad
{
    class EinsteinProblem
    {
        enum Nationality { British, Swedish, Norwegian, Dane, German };
        enum HouseColor { Red, Green, Yellow, Blue, White };
        enum Drink { Tea, Coffee, Milk, Beer, Water };
        enum Cigarette { PallMall, Dunhill, Blends, BlueMaster, Prince };
        enum Pet { Dog, Bird, Cat, Horse, Fish };
        private class Tenant
        {
            public Nationality n;
            public HouseColor h;
            public Drink d;
            public Cigarette c;
            public Pet p;
        }

        public static void Run()
        {
            Tenant t0 = new Tenant();
            Tenant t1 = new Tenant();
            Tenant t2 = new Tenant();
            Tenant t3 = new Tenant();
            Tenant t4 = new Tenant();
            int count = 0;
            DateTime startTime = DateTime.UtcNow;
            foreach (List<Nationality> listNationality in GetPermutation<Nationality>())
            {
                // some quick optimization. the same condition is checked again when evaluating
                // a particular enumeration, which is really redundant but that's ok
                if (listNationality[0] != Nationality.Norwegian)
                    continue;

                t0.n = listNationality[0];
                t1.n = listNationality[1];
                t2.n = listNationality[2];
                t3.n = listNationality[3];
                t4.n = listNationality[4];
                foreach (List<HouseColor> listHouseColor in GetPermutation<HouseColor>())
                {
                    if (listHouseColor[1] != HouseColor.Blue)
                        continue;

                    t0.h = listHouseColor[0];
                    t1.h = listHouseColor[1];
                    t2.h = listHouseColor[2];
                    t3.h = listHouseColor[3];
                    t4.h = listHouseColor[4];
                    foreach (List<Drink> listDrink in GetPermutation<Drink>())
                    {
                        if (listDrink[2] != Drink.Milk)
                            continue;

                        t0.d = listDrink[0];
                        t1.d = listDrink[1];
                        t2.d = listDrink[2];
                        t3.d = listDrink[3];
                        t4.d = listDrink[4];
                        foreach (List<Cigarette> listCigarette in GetPermutation<Cigarette>())
                        {
                            t0.c = listCigarette[0];
                            t1.c = listCigarette[1];
                            t2.c = listCigarette[2];
                            t3.c = listCigarette[3];
                            t4.c = listCigarette[4];
                            foreach (List<Pet> listPet in GetPermutation<Pet>())
                            {
                                t0.p = listPet[0];
                                t1.p = listPet[1];
                                t2.p = listPet[2];
                                t3.p = listPet[3];
                                t4.p = listPet[4];
                                List<Tenant> currentMapping = new List<Tenant>() { t0, t1, t2, t3, t4 };
                                if (Evaluate(currentMapping))
                                {
                                    Console.WriteLine("Found answer:");
                                    Console.WriteLine("Tenant 0 - Nationality: {0}, HouseColor: {1}, Drink: {2}, Cigarette: {3}, Pet: {4}", t0.n, t0.h, t0.d, t0.c, t0.p);
                                    Console.WriteLine("Tenant 1 - Nationality: {0}, HouseColor: {1}, Drink: {2}, Cigarette: {3}, Pet: {4}", t1.n, t1.h, t1.d, t1.c, t1.p);
                                    Console.WriteLine("Tenant 2 - Nationality: {0}, HouseColor: {1}, Drink: {2}, Cigarette: {3}, Pet: {4}", t2.n, t2.h, t2.d, t2.c, t2.p);
                                    Console.WriteLine("Tenant 3 - Nationality: {0}, HouseColor: {1}, Drink: {2}, Cigarette: {3}, Pet: {4}", t3.n, t3.h, t3.d, t3.c, t3.p);
                                    Console.WriteLine("Tenant 4 - Nationality: {0}, HouseColor: {1}, Drink: {2}, Cigarette: {3}, Pet: {4}", t4.n, t4.h, t4.d, t4.c, t4.p);
                                    Console.WriteLine("Total running time: {0}, total # of permutation checked: {1}", (DateTime.UtcNow - startTime).TotalSeconds, count);
                                    return;
                                }
                                else
                                {
                                    if (++count % 1000000 == 0)
                                        Console.WriteLine("Enumerated {0} possiblities so far.", count);
                                }
                            }
                        }
                    }
                }
            }
        }

        static IEnumerable<List<T>> GetPermutation<T>()
        {
            List<T> list = Enum.GetValues(typeof(T)).OfType<T>().ToList();
            var result = from a in list
                         from b in list
                         from c in list
                         from d in list
                         from e in list
                         where !a.Equals(b) && !a.Equals(c) && !a.Equals(d) && !a.Equals(e) && !b.Equals(c) && !b.Equals(d) && !b.Equals(e) && !c.Equals(d) && !c.Equals(e) && !d.Equals(e)
                         select new List<T>() { a, b, c, d, e };
            return result;
        }

        static bool Evaluate(List<Tenant> mapping)
        {
            for (int i = 0; i < 5; i++)
            {
                Tenant t = mapping[i];
                Tenant tLeft = (i == 0) ? null : mapping[i - 1];
                Tenant tRight = (i == 4) ? null : mapping[i + 1];

                // notice that condition 8, 9, and 14 actually have already been checked
                // in the for loop

                // pulling the 9th condition to the front for some minor optimization
                if (i == 0 && t.n != Nationality.Norwegian)  // condition 9
                    return false;

                // this is the 14th condition slightly adapted: because the Norwegian
                // lives in the first house so his only neighour is the house to the
                // right (or the second house on the block)
                if (i == 1 && t.h != HouseColor.Blue) // // condition 14
                    return false;

                // same optimization as above
                if (i == 2 && t.d != Drink.Milk) // condition 8
                    return false;

                if (t.n == Nationality.British && t.h != HouseColor.Red)  // condition 1
                    return false;
                if (t.n == Nationality.Swedish && t.p != Pet.Dog) // condition 2
                    return false;
                if (t.n == Nationality.Dane && t.d != Drink.Tea) // condition 3
                    return false;
                if (t.h == HouseColor.Green && (tRight == null || tRight.h != HouseColor.White)) // condition 4
                    return false;
                if (t.h == HouseColor.Green && t.d != Drink.Coffee) // condition 5
                    return false;
                if (t.c == Cigarette.PallMall && t.p != Pet.Bird) // condition 6
                    return false;
                if (t.h == HouseColor.Yellow && t.c != Cigarette.Dunhill) // condition 7
                    return false;
                if (t.c == Cigarette.Blends && (tLeft == null || tLeft.p != Pet.Cat) && (tRight == null || tRight.p != Pet.Cat)) // condition 10
                    return false;
                if (t.p == Pet.Horse && (tLeft == null || tLeft.c != Cigarette.Dunhill) && (tRight == null || tRight.c != Cigarette.Dunhill)) // condition 11
                    return false;
                if (t.c == Cigarette.BlueMaster && t.d != Drink.Beer) // condition 12
                    return false;
                if (t.n == Nationality.German && t.c != Cigarette.Prince) // condition 13
                    return false;
                if (t.c == Cigarette.Blends && (tLeft == null || tLeft.d != Drink.Water) && (tRight == null || tRight.d != Drink.Water)) // condition 15
                    return false;
            }
            return true;
        }
    }
}
