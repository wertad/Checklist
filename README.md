# Checklist++

Munkahelyi segédprogramként funkcionált, az adott munkakörnyezetre (szerverekre) tervezve.

A feladat az volt, hogy a cég számos kritikusan fontos szervereit saját szemmel is ellenőrizzük, hogy biztosan minden megfelelően működik rajta. Így a windows szerverekre rdp-n keresztül, a linuxokra ssh-n, a webes eléréssel rendelkező eszközökhöz pedig egy böngészőn keresztül fértünk hozzá. Majd minden kiszolgálón/eszközön más és más teszteket futtattunk a feladatkörének megfelelően.
Az ellenőrzést követően képernyőmentésekkel dokumentáltuk és mentettük a tapasztaltakat.

Egy teljesen kézzel végzett ellenőrzési folyamat kb. 1,5-2 órát vett igénybe, ezzel a segédprogrammal viszont kb. 20 percre sikerült ezt az időt redukálni.

Funkciói:
- képes volt egy meghatározott mappa- és azokon belül fájlstruktúra létrehozására egy hálózati munkakönyvtárba
- képes volt egy megadott mappában tárolt .rdp fájlokkal tömeges távoli asztali kapcsolatot kezdeményezni
- képes volt kikeresni a registryből, hogy az adott kliens gépen telepítve van-e a paint.net külső program (mellyel a prtscr-elt képeket mentettük le) és ha igen, akkor meghatározni az indítási útvonalát és elindítani a Checklist++ programmal együtt a paint.net-et is. Arra is figyelt, ha már meg van nyitva a paint.net akkor egy figyelmeztető ablakban jelezze a felhazsnálónak, hogy mentsen el benne mindent, és ezután bezárni az előző paint.net process-t és indítani egy újat (erre szükség volt többek között a megfelelő vászonméret miatt)
- képes volt figyelni és jelölni (a listában kizöldezve) azokat a szervereket amikkel már végeztünk az ellenőrzés során. Ezt a Checklist++ program indításakor a hálózatra készített mappa és fájlstruktúra metaadataiból látta, ha az adott feladathoz tartozó fájl már nem 0KB akkor kész.
- a programot egyidejűleg ketten használtuk, és mivel a program hálózatról dolgozott, így láthattuk azt is hogy a másik hol tart, mely szervereket ellenőrizte már, mivel mindkettőnknél zöldültek a megfelelő tételek a listában

![mukodes_kozben2](https://user-images.githubusercontent.com/17532282/194511522-eeab4f5d-ef6a-4d4a-8ca5-5db36ea5acb5.png)

Miután az alapfunkciókat a program már ellátta, később kerültek bele extra funkciók is:
- hangvezérelés, megadott parancsszavakra lehetett indítani pl. az első tíz tételt, vagy csak amik nincsenek készen stb. (igazából soha nem használtuk, pusztán szakmai kíváncsiság és fejlődés miatt írtam meg, de működött)
- a hangutasítást követően a program különböző soundpack-ekkel jelezte ha vette az utasítást, pl. a warcraft peonjai hangján "work-work", "zug-zug" stb. :-)
- igény merült fel arra is, hogy megadni a programnak, hogy több monitoros rendszeben melyik kijelzőre pakolja az rdp ablakokat alapértelmezetten, ez a funkció végül nem nyert végleges formát, a win10 ablakkezelési hiányosságai miatt

![mukodes_kozben3](https://user-images.githubusercontent.com/17532282/194525133-0a33df0a-9058-41dd-b599-12a5d5abe95e.png)
