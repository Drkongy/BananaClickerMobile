import math
Intelligence = 1
Production = 1e38


for i in range(250):
    Intelligence = Intelligence * 10
    #test = Production * (1 + (Intelligence * 0.005))
    #Production = Production *2
    Production = Production * 10
    #test = (math.pow(10,4)*(Production / math.sqrt(math.pow(10,4.5)))) / 1e40
    #test = math.log(Production)* math.pow(10,3) - 250
    #test = (math.pow(Production, 1/2)*10
    test = 1000 * (math.sqrt(Production/1e45))
    
    print(Production,  ":      ",  test)

    



