package src;

import java.util.Comparator;

public class PairComparator implements Comparator<Pair> {

    public int compare(Pair pair1, Pair pair2) {
        if (pair1.weight < pair2.weight)
            return -1;
        if (pair1.weight > pair2.weight)
            return 1;
        return 0;
    }
}