

int countOdds(int low, int high){
    int k=(high-low)/2;
        // if(high%2!=0||low%2!=0)k++;
        // return k;
    if(high & 1 || low & 1)
        k++;
    return k;
    
}