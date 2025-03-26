# UI_RPG_hw


OOP principi

Šajā projektā es izmantoju četrus objektorientētās programmēšanas principus:

- Mantošana : tika izveidota bāzes klase `Character`, no kuras manto gan spēlētājs (`Player`), gan pretinieks (`Enemy`). Kā arī `Weapon` klase, no kuras manto dažādi ieroči.
  
- Enkapsulācija: i `getter` un `setter` metodes = `GetHealth()` un `SetHealth()`.

- Polimorfisms: 
  - metode (`override`): `Attack()` 
  - metodes  (`overload`): `GetHit()` metode, kas pieņem papildu parametru kritiskajam trāpījumam


- Abstrakcija: abstraktā klase `Weapon` ar metodi `GetDamage()` un abstrakto metodi `ApplyEffect()`. No tās manto `FireWeapon` un `IceWeapon`, kas katra realizē savu efektu

papildus uzdevums :

es realizēju(`buffs and healing`):
- kur spēlētājs var izmantot dziedēšanu, lai atjaunotu dzīvības
- un spēka palielināšanas (`buff`) iespēja, kas īslaicīgi uzlabo uzbrukumu


