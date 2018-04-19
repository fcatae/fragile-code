# fragile-code
Desafio refactoring. Falaram que esse código está wordy e frágil. O que vc ajustaria?

Comente no Post original: https://www.linkedin.com/feed/update/urn:li:activity:6392363160237543424

## Enunciado original do teste

Nós temos uma classe representando nós de árvores binárias:

```` CS
class BTN { 
    int val; 
    BTN left; 
    BTN right; 
}
````
Por favor, implemente o método para comparar 2 dessas árvores (retornos: verdadeiro se totalmente igual, falso - caso contrário)

## Sugestão 1: Comparar as classes recursivamente

A função `BTreesAreEquals` pode tratar 3 casos diferentes:

```
    bool BTreesAreEquals(BTN a, BTN b)
    {
        // se AMBOS forem nulos, então são iguais
        if( a == null && b == null )
            return true;

        // se SOMENTE UM for nulo, então são diferentes
        if( a == null || b == null )
            return false;

        // AMBOS são NÃO-NULOS, então todas propriedades devem ser iguais
        return (a.val == b.val) &&
                BTreesAreEquals(a.left, b.left) &&
                BTreesAreEquals(a.right, b.right);
    }
```

Dessa forma, não é necessário transformar a estrutura `BTN` em `String` usando 
a função `BTreeAsString`. A vantagem é evitar a serialização do objeto.


## Sugestão 2: Adicionar um construtor em BTN

Adicionado um construtor na classe BTN para receber o valor e associar ao campo `val`. 

Isso torna a sintaxe mais legível:

```
    BTN a = new BTN(1)
    {
        left = new BTN(2),
        right = new BTN(3)
        {
            left = new BTN(4),
            right = new BTN(5)
        }
    };
```

Ao invés de:

```
    BTN a = new BTN
    {
        val = 1,
        left = new BTN
        {
            val = 2
        },
        right = new BTN
        {
            val = 3,
            left = new BTN
            {
                val = 4
            },
            right = new BTN
            {
                val = 5
            }
        }
    };
```
