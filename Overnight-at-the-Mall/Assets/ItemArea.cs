using UnityEngine;
using System.Collections;

public class ItemArea : MonoBehaviour {
	
	public int itemRows;
	public int itemColumns;
	
	public GameObject fillItem;

	// TODO: Population pattern enums?

	// Use this for initialization
	void Start () {
		var areaSize = this.gameObject.transform.lossyScale;

		var itemSize = fillItem.transform.lossyScale;
		var horizontalStep = Mathf.Max(itemSize.x, areaSize.x / (itemColumns + 1));
		var verticalStep = Mathf.Max(itemSize.y, areaSize.y / (itemRows + 1));

		var lowerLeft = this.gameObject.transform.position - areaSize / 2;

		for (var x = horizontalStep; x + itemSize.x < areaSize.x; x += horizontalStep) {
			for (var y = verticalStep; y + itemSize.y < areaSize.y; y += verticalStep) {
				Instantiate(fillItem, lowerLeft + new Vector3(x, y, 0), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	}
}
