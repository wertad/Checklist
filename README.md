# Checklist++

Munkahelyi segédprogramként funkcionált, az adott munkakörnyezetre (szerverekre) tervezve.

A feladat az volt, hogy a cég számos kritikusan fontos szervereit saját szemmel is ellenőrizzük, hogy biztosan minden megfelelően működik rajta. Így a windows szerverekre rdp-n keresztül, a linuxokra ssh-n, a webes eléréssel rendelkező eszközökhöz pedig egy böngészőn keresztül fértünk hozzá. Majd minden kiszolgálón/eszközön más és más teszteket futtattunk a feladatkörének megfelelően.
Az ellenőrzést követően képernyőmentésekkel dokumentáltuk és mentettük a tapasztaltakat.

Funkciói:
- képes volt egy meghatározott mappa- és azokon belül fájlstruktúra létrehozására egy hálózati munkakönyvtárba
- képes volt egy megadott mappában tárolt .rdp fájlokkal tömeges távoli asztali kapcsolatot kezdeményezni
- képes volt kikeresni a registryből, hogy az adott kliens gépen telepítve van-e a paint.net külső program (mellyel a prtscr-elt képeket mentettük le) és ha igen, akkor meghatározni az indítási utvonalát és elindítani a Checklist++ programmal együtt a paint.net-et is. Arra is figyelt, ha már meg van nyitva a paint.net akkor egy figyelmeztető ablakban jelezze a felhazsnálónak, hogy mentsen el benne mindent, és ezután bezárni az előző paint.net process-t és indítani egy újat (erre szükség volt többek között a megfelelő vászonméret miatt)
- ha telepítve volt 

![mukodes_kozben2](https://user-images.githubusercontent.com/17532282/194511522-eeab4f5d-ef6a-4d4a-8ca5-5db36ea5acb5.png)


