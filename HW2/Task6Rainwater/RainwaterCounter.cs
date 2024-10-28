namespace Task6Rainwater;

public class RainwaterCounter
{
    public static int Count(ref int[] height) {
        int n = height.Length;
        if (n == 0) return 0;

        int left = 0; 
        int right = n - 1;
        var leftMax = 0;
        var rightMax = 0;
        int count = 0;
        while (left < right) {
            if (height[left] < height[right]) {
                if (height[left] >= leftMax) {
                    leftMax = height[left];
                } else {
                    count += leftMax - height[left];
                }
                left++;
            } else {
                if (height[right] >= rightMax) {
                    rightMax = height[right];
                } else {
                    count += rightMax - height[right];
                }
                right--;
            }
        }
        return count;
    }
}