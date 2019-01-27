#include<stdio.h>
typedef unsigned char *byte_pointer;
int bis(int x, int m)
{
    return x | m;
}

int bic(int x, int m)
{
    return (x^m)&(~m);
}

int bool_or(int x, int y)
{
    y = bis(y, x);
    x = bis(x, y);
    return x;
}

int bool_xor(int x, int y)
{
    int xc = bic(x, y);
    int yc = bic(y, x);
    return bool_or(xc, yc);
}

void print_in_hex(int x)
{
    size_t i;
    size_t length = sizeof(int);
    byte_pointer p = (byte_pointer) &x;
    for(i=0;i<length;i++)
    {
        printf(" %.2x", p[i]);
    }
    printf("\n");
}

int main()
{
    int x = 0x01;
    int y = 0x03;

    int or_ret = bool_or(x, y);
    int xor_ret = bool_xor(x, y);
    print_in_hex(x);
    print_in_hex(y);
    print_in_hex(or_ret);
    print_in_hex(xor_ret);

    return 0;
}