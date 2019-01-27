#include<stdio.h>

typedef unsigned char *byte_porinter;

void show_bytes(byte_porinter start, size_t length)
{
    size_t i;
    for(i=0;i<length;i++)
    {
        printf(" %.2x", start[i]);
    }
    printf("\n");
}

void show_int(int x)
{
    show_bytes((byte_porinter) &x, sizeof(int));
}

void show_float(float x)
{
    show_bytes((byte_porinter) &x, sizeof(float));
}

void show_pointer(void *x)
{
    show_bytes((byte_porinter) &x, sizeof(void *));
}

int main(){
    int a = 11;
    show_int(a);

    float b = 11;
    show_float(b);

    int *p = &a;
    show_pointer(p);
    return 0;
}