/**
 * Scrivi un piccolo programma che stampi ogni numero da 1 a 100 su una nuova riga.
    Per ogni multiplo di 3, stampa “Foo” invece del numero. 
    Per ogni multiplo di 5, stampa “Bar” invece del numero. 
    Per ogni numero multiplo di 3 e 5 insieme, stampa “FooBar” invece del numero.
 */
/**Mannino Francesco - 12/10/2023 */

let length = 100;

for (let i = 1; i <= length; i++) {
    if (i % 3 == 0 && i % 5 == 0) {
        console.log("FooBar")
    } else if (i % 3 == 0) {
        console.log("Foo")
    } else if (i % 5 == 0) {
        console.log("Bar")
    } else {
        console.log(i);
    }
}